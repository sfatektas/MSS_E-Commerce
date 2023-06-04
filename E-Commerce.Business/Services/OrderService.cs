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
using Microsoft.VisualBasic;
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
            double total_price = 0;

            List<OrderDetail> orderDetails = new();

            var order = _mapper.Map<Order>(model);
            order.OrderStatusTypeId = (int)Common.Enums.OrderStatusType.SiparisAlindi;

            order.OrderDetails = null;

            var productInStocks = _uow.GetRepository<ProductsInStock>().GetQueryable();

            foreach (var orderdetailmodel in model.OrderDetails)
            {
                var data = await productInStocks.FirstOrDefaultAsync(x => x.Id == orderdetailmodel.ProductInStockId);
                if (data.Amount - orderdetailmodel.Amount < 0)
                    throw new OrderCreateBadRequestExeption($"{data.Id}'ye sahip urunde yeterli stok bulunmamaktadır.");
                data.Amount -= orderdetailmodel.Amount;

                total_price += data.UnitPrice * orderdetailmodel.Amount;

                orderDetails.Add(new OrderDetail
                {
                    Amount = orderdetailmodel.Amount,
                    UnitPrice = data.UnitPrice,
                    TotalPrice = data.UnitPrice * orderdetailmodel.Amount,
                    SupplierProductId = data.SupplierProductId,
                });
            }
            order.TotalPrice = total_price;

            await _uow.GetRepository<Order>().CreateAsync(order);
            await _uow.SaveChangesAsync();

            var nowOrder = await _uow.GetRepository<Order>().GetByFilterAsync(x =>
                x.CreatedDate == model.CreatedDate &&
                x.CustomerId == model.CustomerId);

            if (nowOrder == null)
                throw new OrderNotFoundException("Siparise ait kayıt olustururken hata olustu");

            //var details = _mapper.Map<List<OrderDetail>>(model.OrderDetails);

            orderDetails.ForEach(x => x.OrderId = nowOrder.Id);


            await _uow.GetRepository<OrderDetail>().MultipleCreateAsynct(orderDetails);
            await _uow.SaveChangesAsync();
        }
        public async Task<List<CustomerOrderListModel>> GetCustomerOrders(int id)
        {
            List<CustomerOrderListModel> customerOrderList = new List<CustomerOrderListModel>();
            List<CustomerOrderDetailListModel> customerOrderDetail = new List<CustomerOrderDetailListModel>();
            var orders = await _uow.GetRepository<Order>()
                .GetAllAsync(x => x.CustomerId == id)
                .Include(x => x.Customer)
                .Include(x => x.OrderStatusType)
                .Include(x => x.OrderDetails)
                .ToListAsync();

            if (orders == null)
                throw new OrderNotFoundException();

            foreach (var order in orders)
            {
                customerOrderDetail.Clear();

                foreach (var orderDetail in order.OrderDetails)
                {
                    var productInStock = await _uow.GetRepository<ProductsInStock>().GetQueryable()
                        .Where(x => x.SupplierProductId == orderDetail.SupplierProductId)
                        .Include(x => x.SupplierProduct)
                            .Include(x => x.SupplierProduct.Supplier)
                        .FirstOrDefaultAsync();


                    customerOrderDetail.Add(new CustomerOrderDetailListModel()
                    {
                        ProductInStockId = productInStock.Id,
                        ProductTitle = productInStock.SupplierProduct.CustomProductTitle,
                        ProductDefination = productInStock.SupplierProduct.CustomProductDefination,
                        SupplierUsername = productInStock.SupplierProduct.Supplier.UserName,
                        SupplierId = productInStock.SupplierProduct.SupplierId,
                        Amount = orderDetail.Amount,
                        UnitPrice = orderDetail.UnitPrice,
                        TotalPrice = orderDetail.TotalPrice,
                    });
                }
                customerOrderList.Add(
                    new CustomerOrderListModel()
                    {
                        OrderStatusValue = order.OrderStatusType.Defination,
                        TotalPrice = order.TotalPrice,
                        OrderDate = order.CreatedDate,
                        CustomerOrderDetails = customerOrderDetail
                    });

            }



            return customerOrderList;
        }

        public async Task<List<CustomOrderDetailsListModel>> GetProductInStocksOrder(int ProductInStockId)
        {
            var productsInStock = await _uow.GetRepository<ProductsInStock>().GetByFilterAsync(x => x.Id == ProductInStockId);

            if (productsInStock == null)
                throw new OrderNotFoundException();

            var orderDetails = await _uow.GetRepository<OrderDetail>()
                .GetQueryable()
                .Where(x => x.SupplierProductId == productsInStock.SupplierProductId)
                .Include(x => x.SupplierProduct)
                    .Include(x => x.SupplierProduct.Supplier)
                .Include(x => x.Order)
                    .Include(x => x.Order.Customer)
                .ToListAsync();


            return _mapper.Map<List<CustomOrderDetailsListModel>>(orderDetails);

        }

        public async Task Tamamlandi(int orderId)
        {
            var order = await _uow.GetRepository<Order>().GetByFilterAsync(x => x.Id == orderId && x.OrderStatusTypeId == (int)Common.Enums.OrderStatusType.KargoyaVerildi);

            if (order == null)
                throw new OrderNotFoundException("Bu Id'ye ve sipariş türüne ait Order bulunamadı");

            order.OrderStatusTypeId = (int)Common.Enums.OrderStatusType.Tamamlandi;
            _uow.GetRepository<Order>().Update(order);
            await _uow.SaveChangesAsync();


        }

        public async Task IptalEdildi(int orderId)
        {
            var order = await _uow.GetRepository<Order>().GetByFilterAsync(x => x.Id == orderId && (x.OrderStatusTypeId == (int)Common.Enums.OrderStatusType.SiparisAlindi || x.OrderStatusTypeId == (int)Common.Enums.OrderStatusType.KargoyaVerildi));

            if (order == null)
                throw new OrderNotFoundException("Bu Id'ye ve sipariş türüne ait Order bulunamadı");

            order.OrderStatusTypeId = (int)Common.Enums.OrderStatusType.IptalEdildi;
            _uow.GetRepository<Order>().Update(order);
            await _uow.SaveChangesAsync();


        }

        public async Task KargoyaVerildi(int orderId)
        {
            var order = await _uow.GetRepository<Order>().GetByFilterAsync(x => x.Id == orderId && x.OrderStatusTypeId == (int)Common.Enums.OrderStatusType.SiparisAlindi);

            if (order == null)
                throw new OrderNotFoundException("Bu Id'ye ve sipariş türüne ait Order bulunamadı");

            order.OrderStatusTypeId = (int)Common.Enums.OrderStatusType.KargoyaVerildi;

            _uow.GetRepository<Order>().Update(order);
            await _uow.SaveChangesAsync();
        }



    }
}
