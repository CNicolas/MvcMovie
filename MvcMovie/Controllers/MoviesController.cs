using MvcMovie.DAL;
using MvcMovie.DTO;
using MvcMovie.Models;
using MvcMovie.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        IMoviesRepository _moviesRepository;
        IActorsRepository _actorsRepository;
        IMovieActorRepository _movieActorRepository;

        public MoviesController(IMoviesRepository moviesRepository, IActorsRepository actorsRepository, IMovieActorRepository movieActorRepository)
        {
            _moviesRepository = moviesRepository;
            _actorsRepository = actorsRepository;
            _movieActorRepository = movieActorRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = CreateMoviesViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            var model = new AddMovieViewModel() { Actors = GetAllActorsAsSelectedListItem() };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel viewModel)
        {
            if (!ModelState.IsValid || viewModel.Movie == null)
            {
                return View(viewModel);
            }

            _moviesRepository.CreateMovie(viewModel.Movie);
            foreach (int aId in viewModel.SelectedActors)
            {
                var ma = new MovieActor() { MovieId = viewModel.Movie.Id, ActorId = aId };
                _movieActorRepository.CreateMovieActor(ma);
            }

            var newViewModel = CreateMoviesViewModel();
            return View("Index", newViewModel);
        }


        #region Private Methods

        private MoviesViewModel CreateMoviesViewModel()
        {
            var viewModel = new MoviesViewModel();
            viewModel.AllMovies = _moviesRepository.FindAll().Select(m => new MovieDto(m)).ToList();
            viewModel.AllActors = _actorsRepository.FindAll();

            foreach (MovieDto m in viewModel.AllMovies)
            {
                m.Actors = _movieActorRepository.GetActorsOfMovie(m.Movie);
            }

            return viewModel;
        }

        private IEnumerable<SelectListItem> GetAllActorsAsSelectedListItem()
        {
            return _actorsRepository.FindAll().Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Fullname });
        }

        #endregion
    }
}