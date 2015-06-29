using Abp.Domain.Repositories;
using AutoMapper;
using Exchange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Offers
{
    public class OffersAppService : ExchangeAppServiceBase, IOffersAppService
    {
        private readonly IRepository<Offer, long> _offerRepository;
        private readonly IRepository<Order, long> _orderRepository;

        public OffersAppService(IRepository<Offer, long> offerRepository, IRepository<Order, long> orderRepository)
        {
            _offerRepository = offerRepository;
            _orderRepository = orderRepository;
        }

        public async void AddOffer(OfferDto offer)
        {
            Mapper.CreateMap<OfferDto, Offer>()
                .ForMember(o => o.Status, opts => opts.Ignore());
            var offerEntity = Mapper.Map<OfferDto, Offer>(offer);

            await _offerRepository.InsertAsync(offerEntity);
        }


        public void AcceptOffer(OfferDto offer)
        {
            var orderEntity = _orderRepository.Get(offer.OrderId);
            var offerEntities = _offerRepository.GetAllList(o => o.OrderId == offer.OrderId);

            orderEntity.Close();

            foreach (var offerEntity in offerEntities)
            {
                if (offerEntity.Id == offer.Id)
                {
                    offerEntity.Accept();
                }

                else
                {
                    offerEntity.Reject();
                }
            }            
        }
    }
}
