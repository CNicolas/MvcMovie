using MvcMovie.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MvcMovie.DAL
{
    public class MoviesRepository : IMoviesRepository
    {
        public List<Movie> FindAll()
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.Movies.ToList();
            }
        }

        public Movie FindById(int id)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.Movies.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public List<Movie> FindByIds(IEnumerable<int> ids)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.Movies.Where(m => ids.Contains(m.Id)).ToList();
            }
        }


        public bool CreateMovie(Movie movie)
        {
            try
            {
                using (MvcMovieContext ctx = new MvcMovieContext())
                {
                    ctx.Movies.Add(movie);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}