using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public interface IActorService
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);

    }
}
