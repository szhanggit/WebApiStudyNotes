using System.Web.Http;
using System.Web.Mvc;

namespace ExampleApp.Controllers {
    public class FormattersController : Controller {

        public ActionResult Index() {
            return View(GlobalConfiguration.Configuration.Formatters);
        }

        /*
         http://localhost:29844/Formatters/Index
         */
    }
}
