using MvcMovie.Models;
using System.Collections.Generic;

namespace MvcMovie.DAL
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        List<Actor> GetActorsOfMovie(Movie m);
    }
}
