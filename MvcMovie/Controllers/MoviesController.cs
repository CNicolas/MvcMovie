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
        public ActionResult Index(string error)
        {
            var viewModel = new MoviesViewModel();
            viewModel.AllMovies = _moviesRepository.FindAll().Select(m => new MovieDto(m)).ToList();
            viewModel.AllActors = _actorsRepository.FindAll();

            foreach (MovieDto m in viewModel.AllMovies)
            {
                m.Actors = _movieActorRepository.GetActorsOfMovie(m.Movie);
            }

            ViewBag.Error = error;
            return View(viewModel);
        }


        #region Add Movie

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

            var successfullyAdded = _moviesRepository.CreateMovie(viewModel.Movie);
            if (!successfullyAdded)
            {
                return Redirect(string.Format("Index?error={0} {1}", viewModel.Movie.Name, "Already exists"));
            }

            if (viewModel.SelectedActors != null)
            {
                foreach (int aId in viewModel.SelectedActors)
                {
                    var ma = new MovieActor() { MovieId = viewModel.Movie.Id, ActorId = aId };
                    _movieActorRepository.CreateMovieActor(ma);
                }
            }

            return Redirect("Index");
        }

        #endregion


        #region Add Actor

        [HttpGet]
        public ActionResult AddActor()
        {
            var model = new AddActorViewModel() { Movies = GetAllMoviesAsSelectedListItem() };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddActor(AddActorViewModel viewModel)
        {
            if (!ModelState.IsValid || viewModel.Actor == null)
            {
                return View(viewModel);
            }

            var successfullyAdded = _actorsRepository.CreateActor(viewModel.Actor);
            if (!successfullyAdded)
            {
                return Redirect(string.Format("Index?error={0} {1}", viewModel.Actor.Fullname, "Already exists"));
            }

            if (viewModel.SelectedMovies != null)
            {
                foreach (int mId in viewModel.SelectedMovies)
                {
                    var ma = new MovieActor() { ActorId = viewModel.Actor.Id, MovieId = mId };
                    _movieActorRepository.CreateMovieActor(ma);
                }
            }

            return Redirect("Index");
        }

        #endregion


        #region Private Methods

        private IEnumerable<SelectListItem> GetAllActorsAsSelectedListItem()
        {
            return _actorsRepository.FindAll().Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Fullname });
        }

        private IEnumerable<SelectListItem> GetAllMoviesAsSelectedListItem()
        {
            return _moviesRepository.FindAll().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });
        }

        #endregion
    }
}