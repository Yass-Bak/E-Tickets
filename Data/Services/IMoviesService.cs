using E_Tickets.Data.Base;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues();
        Task addNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
