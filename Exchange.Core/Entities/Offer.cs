using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Entities
{
    public class Offer : FullAuditedEntity<long>
    {
        public Offer()
        {
            Status = "Oczekuje";
        }

        public void Accept()
        {
            Status = "Zaakceptowana";
        }

        public void Reject()
        {
            Status = "Odrzucona";
        }

        [Required]        
        public virtual long OrderId { get; protected set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; protected set; }
        [Required]
        public virtual string Status { get; protected set; }
    }
}
