using Autofac;
using MvcMovie.Tools;
using MvcMovie.ViewModels;
using System.Web.Mvc;
using MvcMovie.App_Start;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = DependeciesInjectionContainer.Container.Resolve<MoviesViewModel>();
            return View(viewModel);
        }
    }
}