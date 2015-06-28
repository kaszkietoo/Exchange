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
        private readonly IRepository<Offer, long> _offerRepository;

        public OrdersAppService(IRepository<Order, long> ordersRepository, IRepository<Offer, long> offerRepository)
        {
            _ordersRepository = ordersRepository;
            _offerRepository = offerRepository;
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
                var wasOfferSent = _offerRepository                    
                    .FirstOrDefault(o => o.OrderId == freight.Id && o.CreatorUserId == AbpSession.UserId) != null;                
                Mapper.CreateMap<Order, OrderDto>()
                .ForMember(o => o.LoadingDate, opts => opts.MapFrom(f => f.LoadingDate.ToString()))
                .ForMember(o => o.UnloadingDate, opts => opts.MapFrom(f => f.UnloadingDate.ToString()));
                var freightDto = Mapper.Map<Order, OrderDto>(freight);
                freightDto.WasOfferSent = wasOfferSent;
                freightDtos.Add(freightDto);
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
                var wasOfferSent = _offerRepository
                    .FirstOrDefault(o => o.OrderId == truck.Id && o.CreatorUserId == AbpSession.UserId) != null;
                Mapper.CreateMap<Order, OrderDto>()
                .ForMember(o => o.LoadingDate, opts => opts.MapFrom(t => t.LoadingDate.ToString()))
                .ForMember(o => o.UnloadingDate, opts => opts.MapFrom(t => t.UnloadingDate.ToString()));

                var truckDto = Mapper.Map<Order, OrderDto>(truck);
                truckDto.WasOfferSent = wasOfferSent;

                truckDtos.Add(truckDto);
            }

            return new OrdersOutput
            {
                Orders = truckDtos
            };
        }        
    }
}
