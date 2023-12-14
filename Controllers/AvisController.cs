using E_Tickets.Data;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class AvisController : Controller
    {
        private AppDbContext _context; // Remplacez ApplicationDbContext par le nom de votre contexte de base de données

        public AvisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AjouterAvis(Avis nouvelAvis)
        {
            // Logique pour ajouter l'avis à la base de données
            _context.Avis.Add(nouvelAvis);
            _context.SaveChanges();

            return RedirectToAction("Details", "Movies", new { Id = nouvelAvis.MovieId });
        }
    }
}
