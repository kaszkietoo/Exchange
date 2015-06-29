using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Entities
{
    public class Order : FullAuditedEntity<long>
    {
        public Order()
        {
            IsClosed = false;
        }

        public void Close()
        {
            IsClosed = true;
        }

        [Required]
        public virtual string CarBody { get; protected set; }
        [Required]
        public virtual float Capacity { get; protected set; }
        [Required]
        public virtual float Length { get; protected set; }
        [Required]
        public virtual decimal Price { get; protected set; }
        [Required]        
        public virtual string Currency { get; protected set; }
        [Required]
        public virtual string Visibility { get; protected set; }
        [Required]
        public virtual bool Partial { get; protected set; }
        [Required]
        public virtual string CountryFrom { get; protected set; }
        [Required]
        public virtual string CityFrom { get; protected set; }
        [Required]
        public virtual DateTime LoadingDate { get; protected set; }
        [Required]
        public virtual string CountryTo { get; protected set; }
        [Required]
        public virtual string CityTo { get; protected set; }
        [Required]
        public virtual DateTime UnloadingDate { get; protected set; }
        [Required]
        public virtual string Type { get; protected set; }
        [Required]
        public virtual bool IsClosed { get; protected set; }
    }
}
