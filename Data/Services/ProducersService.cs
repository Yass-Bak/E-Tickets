using E_Tickets.Data.Base;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer> , IProducersService
    {
        public ProducersService(AppDbContext context) :base(context) { }

    }
}
