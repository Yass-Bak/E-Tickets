using E_Tickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            // var allMovies = await _context.Movies.Include(n => n.Cinema).ToListAsync();

            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }
    }
}
