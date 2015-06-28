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

        public OffersAppService(IRepository<Offer, long> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async void AddOffer(OfferDto offer)
        {
            Mapper.CreateMap<OfferDto, Offer>()
                .ForMember(o => o.Status, opts => opts.Ignore());
            var offerEntity = Mapper.Map<OfferDto, Offer>(offer);

            await _offerRepository.InsertAsync(offerEntity);
        }
    }
}
