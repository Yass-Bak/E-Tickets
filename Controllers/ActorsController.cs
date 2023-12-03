﻿using E_Tickets.Data;
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
        public async Task<IActionResult> Index()
        {
            var data =await  _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
                if (!ModelState.IsValid)
                {
                    return View(actor);
                }
               await  _service.AddAsync(actor);
                return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details (int id)
        {
            var actorDetails =await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Vide");
                    return View(actorDetails);
        }
        public async  Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Vide");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
               return View(actor);
            }
            if (id == actor.Id)
            {
                await _service.UpdateAsync(id, actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Vide");
            return View(actorDetails);
        }
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Vide");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}