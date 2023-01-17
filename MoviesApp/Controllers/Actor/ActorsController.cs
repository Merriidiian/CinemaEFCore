using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Filters;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.Services.Actor.Dto;
using MoviesApp.ViewModels.Actor;



namespace MoviesApp.Controllers
{
    public class ActorsController: Controller
    {
        private readonly IActorService _service;
        private readonly ILogger<HomeController> _logger;


        public ActorsController(IActorService service, ILogger<HomeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: Actors
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var actors = _service.GetAllActors();
            return View(actors);
        }

        // GET: Actors/Details/5
        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _service.GetActor((int)id);

            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
        
        // GET: Actors/Create
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FilterLengthFirstAndLastNameActors]
        [Authorize(Roles = "Admin")] 
        public IActionResult Create([Bind("Name,Surname,BirthDate")] ActorDto inputModel)
        {
            if (ModelState.IsValid)
            {
                _service.AddActor(inputModel);
                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _service.GetActor((int) id);
            
            if (editModel == null)
            {
                return NotFound();
            }
            
            return View(editModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FilterLengthFirstAndLastNameActors]
        [Authorize(Roles = "Admin")] 
        public IActionResult Edit(int id, [Bind("Name,Surname,BirthDate")] ActorDto editModel)
        {
            if (ModelState.IsValid)
            {
                editModel.Id = id;
                var actor = _service.UpdateActor(editModel);
                if ( actor == null)
                {
                    NotFound();
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        // GET: Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = _service.GetActor((int) id);
            
            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }
        
        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")] 
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _service.DeleteActor(id);
            if (actor == null)
            {
                return NotFound();
            }
            _logger.LogTrace($"Actor with id {actor.Id} has been deleted!");
            return RedirectToAction(nameof(Index));
        }
    }
}