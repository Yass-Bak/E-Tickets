using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public class ActorsService : IActorService
    {
        private readonly AppDbContext _context;
        public ActorsService(  AppDbContext context)
        {
            _context = context;
    }
        public void Add(Actor actor)
        {
           _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll()
        {
            var result = _context.Actors.ToList();
            return result;
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
