using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using eTickets.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _service;
            

        public ActorsController(IActorService service)
        {
            _service = service;

        }
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

    }
}