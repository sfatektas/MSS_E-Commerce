using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.OrderDetailDtos;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class OrderService : Service<OrderCreateDto, OrderListDto, OrderUpdateDto, Order>, IOrderService
    {

        private IMapper _mapper;
        private IUow _uow;

        public OrderService(IMapper mapper, IUow uow, IValidator<OrderCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
            _mapper = mapper;
            _uow = uow;
        }


        public async Task<List<OrderListDto>> GetAllOrders()
        {
            var list = await _uow.GetRepository<Order>().GetQueryable().Include(x => x.Customer).Include(x => x.OrderStatusType).Include(x => x.OrderDetails).ToListAsync();
            if (list == null)
                throw new OrderNotFoundException();
            return _mapper.Map<List<OrderListDto>>(list);
        }

        public async Task CreateAsyncOrder(CustomOrderCreateModel model)
        {

            var order = _mapper.Map<Order>(model);
            order.OrderStatusTypeId = (int)Common.Enums.OrderStatusType.SiparisAlindi;
            var details = _mapper.Map<List<OrderDetail>>(model.OrderDetailss);
            var productInStocks = _uow.GetRepository<ProductsInStock>().GetQueryable();
            foreach (var item in details)
            {
                var data = await productInStocks.FirstOrDefaultAsync(x => x.SupplierProductId == item.SupplierProductId);
                if (data.Amount - item.Amount < 0)
                    throw new OrderCreateBadRequestExeption($"{item.Id}'ye sahip urunde yeterli stok bulunmamaktadır.");
                data.Amount -= item.Amount;
            }
            await _uow.GetRepository<Order>().CreateAsync(order);
            await _uow.SaveChangesAsync();

            var nowOrder = await _uow.GetRepository<Order>().GetByFilterAsync(x =>
            x.CreatedDate == model.CreatedDate &&
            x.CustomerId == model.CustomerId);

            if (nowOrder == null)
                throw new OrderNotFoundException("Siparise ait kayıt olustururken hata olustu");

            details.ForEach(x => x.Id = nowOrder.Id);

            await _uow.GetRepository<OrderDetail>().MultipleCreateAsynct(details);
            await _uow.SaveChangesAsync();



        }


    }
}
