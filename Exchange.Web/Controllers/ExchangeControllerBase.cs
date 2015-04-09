using Abp.Web.Mvc.Controllers;

namespace Exchange.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class ExchangeControllerBase : AbpController
    {
        protected ExchangeControllerBase()
        {
            LocalizationSourceName = ExchangeConsts.LocalizationSourceName;
        }
    }
}