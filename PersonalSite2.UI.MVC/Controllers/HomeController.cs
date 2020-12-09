using System.Web.Mvc;

namespace PersonalSite2.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public ActionResult Resume()
        {
            ViewBag.Message = "Your resume page.";

            return View();
        }



        [HttpGet]
        public ActionResult Links()
        {
            ViewBag.Message = "Your links page.";
            return View();
        }

        [HttpGet]
        public ActionResult Projects()
        {
            ViewBag.Message = "Your projects page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}
