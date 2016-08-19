using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private const string _indexView = "Index";

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "HomePageMessage";
            return View();
        }
    }
}