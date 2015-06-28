using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Orders
{
    public class OrdersOutput : IOutputDto
    {
        public List<OrderDto> Orders { get; set; }
    }
}
