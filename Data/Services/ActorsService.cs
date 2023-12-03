using E_Tickets.Data.Base;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorsService(AppDbContext context) : base(context)
        {
        }

    }
}
