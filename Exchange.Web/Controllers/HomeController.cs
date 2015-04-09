using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class HomeController : ExchangeControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}