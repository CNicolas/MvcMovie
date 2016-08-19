using Autofac;
using MvcMovie.DAL;
using MvcMovie.Models;
using MvcMovie.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        IMoviesRepository _moviesRepository;
        IActorsRepository _actorsRepository;

        public MoviesController(IMoviesRepository moviesRepository, IActorsRepository actorsRepository)
        {
            _moviesRepository = moviesRepository;
            _actorsRepository = actorsRepository;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = CreateMoviesViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel viewModel)
        {
            if (!ModelState.IsValid || viewModel.Movie == null)
            {
                return View(viewModel);
            }

            viewModel.Movie.Actors = _actorsRepository.FindByIds(viewModel.SelectedActors);
            _moviesRepository.CreateMovie(viewModel.Movie);

            var newViewModel = CreateMoviesViewModel();
            return View("Index", newViewModel);
        }

        private MoviesViewModel CreateMoviesViewModel()
        {
            var viewModel = new MoviesViewModel();
            viewModel.AllMovies = _moviesRepository.FindAll();
            viewModel.AllActors = _actorsRepository.FindAll();

            foreach (Movie m in viewModel.AllMovies)
            {
                m.Actors = _moviesRepository.GetActorsOfMovie(m);
            }

            viewModel.Actors = _actorsRepository.FindAll().Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Fullname }).ToList();
            return viewModel;
        }
    }
}