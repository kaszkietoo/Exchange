using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Exchange.Application.Offers;
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
        private readonly UserManager _userManager;

        public OrdersAppService(
            IRepository<Order, long> ordersRepository, 
            IRepository<Offer, long> offerRepository,
            UserManager userManager)
        {
            _ordersRepository = ordersRepository;
            _offerRepository = offerRepository;
            _userManager = userManager;
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
                .GetAllList(o => o.CreatorUserId != AbpSession.UserId 
                    && o.Type.Equals("Ładunek")
                    && !o.IsClosed);

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
                .GetAllList(o => o.CreatorUserId != AbpSession.UserId 
                    && o.Type.Equals("Pojazd")
                    && !o.IsClosed);

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


        public async Task<OrdersOutput> GetUserOrders()
        {
            var userOrders = _ordersRepository.GetAllList(o => o.CreatorUserId == AbpSession.UserId);
            var orderDtos = new List<OrderDto>();
            
            foreach (var order in userOrders)
            {
                Mapper.CreateMap<Order, OrderDto>()
                .ForMember(o => o.LoadingDate, opts => opts.MapFrom(t => t.LoadingDate.ToString()))
                .ForMember(o => o.UnloadingDate, opts => opts.MapFrom(t => t.UnloadingDate.ToString()));


                var orderDto = Mapper.Map<Order, OrderDto>(order);
                var offers = _offerRepository.GetAllList(o => o.OrderId == order.Id);
                var offerDtos = new List<OfferDto>();

                foreach (var offer in offers)
                {
                    var offerOwner = await _userManager.GetUserByIdAsync(offer.CreatorUserId.Value);
                    var offerDto = new OfferDto
                    {
                        CreatorUserName = offerOwner.UserName,
                        Status = offer.Status,
                        Id = offer.Id,
                        CreationTime = offer.CreationTime.ToString()                        
                    };                    
                    offerDtos.Add(offerDto);
                }

                orderDto.Offers = offerDtos;
                orderDtos.Add(orderDto);
            }

            return new OrdersOutput 
            {
                Orders = orderDtos
            };
        }
    }
}
