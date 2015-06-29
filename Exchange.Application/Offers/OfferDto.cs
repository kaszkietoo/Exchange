using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Offers
{
    public class OfferDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string CreatorUserName { get; set; }
        public string Status { get; set; }
        public string CreationTime { get; set; }
        public bool IsOrderClosed { get; set; }
    }
}
