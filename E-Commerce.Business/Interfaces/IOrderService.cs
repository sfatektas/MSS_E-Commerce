using E_Commerce.Business.Services;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IOrderService : IService<OrderCreateDto,OrderListDto,OrderUpdateDto,Order>
    {
        Task<List<OrderListDto>> GetAllOrders();
    }
}
