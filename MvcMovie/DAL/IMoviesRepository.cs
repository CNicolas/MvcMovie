using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        bool CreateMovie(Movie m);
    }
}
