using MvcMovie.Models;
using System.Collections.Generic;

namespace MvcMovie.DAL
{
    public interface IMovieActorRepository : IRepository<MovieActor>
    {
        List<Actor> GetActorsOfMovie(Movie m);

        List<Movie> GetMoviesOfActor(Actor a);

        bool CreateMovieActor(MovieActor am);
    }
}