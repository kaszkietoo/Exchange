using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Orders
{
    public interface IOrdersAppService : IApplicationService
    {
        void AddOrder(OrderDto order);
        OrdersOutput GetFreights();
        OrdersOutput GetTrucks();
        Task<OrdersOutput> GetUserOrders();
    }
}
