using Abp.Application.Services;
using System.Threading;

namespace Exchange
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ExchangeAppServiceBase : ApplicationService
    {
        protected ExchangeAppServiceBase()
        {
            LocalizationSourceName = ExchangeConsts.LocalizationSourceName;
        }

        protected string UserName
        {
            get { return Thread.CurrentPrincipal.Identity.Name; }
        }
    }
}