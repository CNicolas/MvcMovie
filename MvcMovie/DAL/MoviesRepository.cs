using MvcMovie.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.DAL
{
    public class MoviesRepository : IMoviesRepository
    {
        public MoviesRepository()
        {
            //var pathForJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "movies.json");
            //using (StreamReader r = new StreamReader(pathForJson))
            //{
            //    string json = r.ReadToEnd();
            //    Movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            //}
        }

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

        public List<Actor> GetActorsOfMovie(Movie m)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                var actorIds = ctx.ActorsMovies.Where(am => am.MovieId == m.Id).Select(am => am.ActorId);
                return ctx.Actors.Where(a => actorIds.Contains(a.Id)).ToList();
            }
        }
    }
}