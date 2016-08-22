using MvcMovie.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MvcMovie.DAL
{
    public class ActorsRepository : IActorsRepository
    {
        public List<Actor> FindAll()
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.Actors.ToList();
            }
        }

        public Actor FindById(int id)
        {
            using (MvcMovieContext ctx = new MvcMovieContext())
            {
                return ctx.Actors.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public List<Actor> FindByIds(IEnumerable<int> ids)
        {
            if (ids != null)
            {
                using (MvcMovieContext ctx = new MvcMovieContext())
                {
                    return ctx.Actors.Where(a => ids.Contains(a.Id)).ToList();
                }
            }
            return new List<Actor>();
        }

        public bool CreateActor(Actor actor)
        {
            try
            {
                using (MvcMovieContext ctx = new MvcMovieContext())
                {
                    ctx.Actors.Add(actor);
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