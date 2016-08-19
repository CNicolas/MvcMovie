using MvcMovie.DAL;
using MvcMovie.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.ViewModels
{
    public class MoviesViewModel
    {
        IMoviesRepository _moviesRepository;

        public List<Movie> Movies { get; private set; }
        public Movie Movie { get; set; }

        public MoviesViewModel(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
            Movies = moviesRepository.FindAll();

            foreach (Movie m in Movies)
            {
                m.Actors = _moviesRepository.GetActorsOfMovie(m);
            }

            Movie = new Movie();
        }
    }
}
