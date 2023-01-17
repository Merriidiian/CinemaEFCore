using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Filters;
using MoviesApp.Services;
using MoviesApp.Services.Dto;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    public class MoviesController: Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _service;

        public MoviesController(ILogger<HomeController> logger, IMovieService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: Movies
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }

        // GET: Movies/Details/5
        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var viewModel = _service.GetMovie((int) id);   

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
        
        // GET: Movies/Create
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnsureReleaseDateBeforeNow]
        [Authorize(Roles = "Admin")] 
        public IActionResult Create([Bind("Title,ReleaseDate,Genre,Price")] MovieDto inputModel)
        {
            if (ModelState.IsValid)
            {
                _service.AddMovie(inputModel);
                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _service.GetMovie((int) id);
            
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
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, [Bind("Title,ReleaseDate,Genre,Price")] MovieDto editModel)
        {
            if (ModelState.IsValid)
            {
                editModel.Id = id;
                var movie = _service.UpdateMovie(editModel);
                if ( movie == null)
                {
                    NotFound();
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        // GET: Movies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = _service.GetMovie((int) id);
            
            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }
        
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _service.DeleteMovie(id);
            if (movie==null)
            {
                return NotFound();
            }
            _logger.LogTrace($"Movie with id {movie.Id} has been deleted!");
            return RedirectToAction(nameof(Index));
        }
    }
}