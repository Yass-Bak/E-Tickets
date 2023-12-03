using System.Linq.Expressions;

namespace E_Tickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        //Méthode géniric pour le movie car il implémente des autres classes  
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includePropreties);
        Task<T> GetByIdAsync(int id);
        //Méthode géniric pour le movie car il implémente des autres classes  
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }

}
