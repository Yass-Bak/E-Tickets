using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get : Producers/detail / avec l'id 
        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);
            if (ProducerDetails == null) return View("Vide");
            return View(ProducerDetails);
        }

        //Get Post dans le producers
        //
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            var data = await _service.GetAllAsync();
            if (data.Where(x => x.FullName == producer.FullName).Count() > 0)
            {
                ViewBag.Message = "Producteur existe deja";
                return View();
            }
            else
            {
                await _service.AddAsync(producer);
                return RedirectToAction(nameof(Index));
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);
            if (ProducerDetails == null) return View("Vide");
            return View(ProducerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {

            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);
            if (ProducerDetails == null) return View("Vide");
            return View(ProducerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);
            if (ProducerDetails == null) return View("Vide");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
