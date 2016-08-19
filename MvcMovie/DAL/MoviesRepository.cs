using MvcMovie.Models;
using System.Collections.Generic;
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

        public List<Actor> GetActorsOfMovie(Movie m)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                var actorIds = ctx.MovieActors.Where(am => am.MovieId == m.Id).Select(am => am.ActorId);
                return ctx.Actors.Where(a => actorIds.Contains(a.Id)).ToList();
            }
        }

        public bool CreateMovie(Movie m)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                ctx.Movies.Add(m);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}