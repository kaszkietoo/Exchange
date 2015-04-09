using Abp.Application.Services;

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
    }
}