using E_Tickets.Data.Base;
using E_Tickets.Models;
using System.Linq.Expressions;

namespace E_Tickets.Data.Services
{
    public interface IAvisService : IEntityBaseRepository<Avis>
    {

    }

    public class AvisService : EntityBaseRepository<Avis>, IAvisService
    {
        public AvisService(AppDbContext context) : base(context)
        {

        }
    }
}
