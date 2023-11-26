using E_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult>Index()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View();
        }
    }
}
