using Abp.Authorization;
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
        [AbpAuthorize("CanTest2")]
        public void TestAppService()
        {
                                                                          
        }
    }
}
