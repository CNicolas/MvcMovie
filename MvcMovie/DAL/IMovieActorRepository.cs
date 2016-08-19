using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public interface IMovieActorRepository : IRepository<MovieActor>
    {
        bool CreateMovieActor(MovieActor am);
    }
}