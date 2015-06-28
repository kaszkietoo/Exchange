using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Offers
{
    public interface IOffersAppService : IApplicationService
    {
        void AddOffer(OfferDto offer);
    }
}
