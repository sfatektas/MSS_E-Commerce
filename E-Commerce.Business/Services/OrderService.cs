using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class OrderService: Service<OrderCreateDto, OrderListDto, OrderUpdateDto, Order>, IOrderService
    {

        private IMapper _mapper;
        private IUow _uow;

        public OrderService(IMapper mapper, IUow uow, IValidator<OrderCreateDto> createValidator) : base(uow,mapper,createValidator)
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

        

    }
}
