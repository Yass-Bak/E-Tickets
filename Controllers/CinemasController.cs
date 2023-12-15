using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //Get Post dans le producers
        //
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            var data = await _service.GetAllAsync();
            if (data.Where(x => x.Name == cinema.Name).Count() > 0)
            {
                ViewBag.Message = "Cinema existe deja";
                return View();
            }
            else
            {
                await _service.AddAsync(cinema);
                return RedirectToAction(nameof(Index));
            }

        }
        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("Vide");
            return View(CinemaDetails);
        }

        //Get les cinemas
        public async Task<IActionResult> Edit(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("Vide");
            return View(CinemaDetails);
        }
        //mettre a jourr  les cinemas
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("Vide");
            return View(CinemaDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("Vide");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
