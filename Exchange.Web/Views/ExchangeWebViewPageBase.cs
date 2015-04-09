using Abp.Web.Mvc.Views;

namespace Exchange.Web.Views
{
    public abstract class ExchangeWebViewPageBase : ExchangeWebViewPageBase<dynamic>
    {

    }

    public abstract class ExchangeWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ExchangeWebViewPageBase()
        {
            LocalizationSourceName = ExchangeConsts.LocalizationSourceName;
        }
    }
}