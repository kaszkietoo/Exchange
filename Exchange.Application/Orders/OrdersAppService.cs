using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Exchange.Core.Entities;
using Exchange.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Application.Orders
{
    public class OrdersAppService : ExchangeAppServiceBase, IOrdersAppService
    {
        private readonly IRepository<Order, long> _ordersRepository;

        public OrdersAppService(IRepository<Order, long> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [AbpAuthorize("CanAddOrder")]
        public async void AddOrder(OrderDto order)
        {
            Mapper.CreateMap<OrderDto, Order>()                
                .ForMember(o => o.LoadingDate, opts => opts.UseValue(DateTime.Parse(order.LoadingDate)))
                .ForMember(o => o.UnloadingDate, opts => opts.UseValue(DateTime.Parse(order.UnloadingDate)));                
            var orderEntity = Mapper.Map<OrderDto, Order>(order);

            await _ordersRepository.InsertAsync(orderEntity);                        
        }

        public OrdersOutput GetFreights()
        {
            var freights = _ordersRepository
                .GetAllList(o => o.CreatorUserId != AbpSession.UserId && o.Type.Equals("freight"));

            var freightDtos = new List<OrderDto>();

            foreach (var freight in freights)
            {
                Mapper.CreateMap<Order, OrderDto>()
                .ForMember(o => o.LoadingDate, opts => opts.UseValue(freight.LoadingDate.ToString()))
                .ForMember(o => o.UnloadingDate, opts => opts.UseValue(freight.UnloadingDate.ToString()));

                freightDtos.Add(Mapper.Map<Order, OrderDto>(freight));
            }

            return new OrdersOutput
            {
                Orders = freightDtos
            };
        }

        public OrdersOutput GetTrucks()
        {
            var trucks = _ordersRepository
                .GetAllList(o => o.CreatorUserId != AbpSession.UserId && o.Type.Equals("truck"));

            var truckDtos = new List<OrderDto>();

            foreach (var truck in trucks)
            {
                Mapper.CreateMap<Order, OrderDto>()
                .ForMember(o => o.LoadingDate, opts => opts.UseValue(truck.LoadingDate.ToString()))
                .ForMember(o => o.UnloadingDate, opts => opts.UseValue(truck.UnloadingDate.ToString()));

                truckDtos.Add(Mapper.Map<Order, OrderDto>(truck));
            }

            return new OrdersOutput
            {
                Orders = truckDtos
            };
        }        
    }
}
