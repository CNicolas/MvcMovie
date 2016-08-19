using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public class MovieActorRepository : IMovieActorRepository
    {
        public List<MovieActor> FindAll()
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.MovieActors.ToList();
            }
        }

        public MovieActor FindById(int id)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.MovieActors.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public List<MovieActor> FindByIds(IEnumerable<int> ids)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.MovieActors.Where(m => ids.Contains(m.Id)).ToList();
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

        public List<Movie> GetMoviesOfActor(Actor a)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                var movieIds = ctx.MovieActors.Where(am => am.ActorId == a.Id).Select(am => am.MovieId);
                return ctx.Movies.Where(m => movieIds.Contains(m.Id)).ToList();
            }
        }

        public bool CreateMovieActor(MovieActor am)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                ctx.MovieActors.Add(am);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}