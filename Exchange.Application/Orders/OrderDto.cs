using Exchange.Application.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Orders
{
    public class OrderDto
    {        
        public string CarBody { get; set; }        
        public float Capacity { get; set; }        
        public float Length { get; set; }        
        public decimal Price { get; set; }        
        public string Currency { get; set; }        
        public string Visibility { get; set; }        
        public bool Partial { get; set; }        
        public string CountryFrom { get; set; }        
        public string CityFrom { get; set; }        
        public string LoadingDate { get; set; }        
        public string CountryTo { get; set; }        
        public string CityTo { get; set; }        
        public string UnloadingDate { get; set; }
        public string Type { get; set; }
        public bool WasOfferSent { get; set; }
        public long Id { get; set; }
        public bool IsClosed { get; set; }
        public List<OfferDto> Offers { get; set; }
    }
}
