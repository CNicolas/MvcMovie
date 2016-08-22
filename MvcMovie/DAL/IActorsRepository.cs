using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public interface IActorsRepository : IRepository<Actor>
    {
        bool CreateActor(Actor actor);
    }
}
