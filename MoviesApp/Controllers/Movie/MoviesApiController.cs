using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesApiController:ControllerBase
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public MoviesApiController(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] // GET: /api/movies
        [ProducesResponseType(200, Type = typeof(IEnumerable<MovieViewModel>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<MovieViewModel>> GetMovies()
        {
            var movies = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(_context.Movies.ToList());
            return Ok(movies);
        }
        
        [HttpGet("{id}")] // GET: /api/movies/5
        [ProducesResponseType(200, Type = typeof(MovieViewModel))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var movie = _mapper.Map<MovieViewModel>(_context.Movies.FirstOrDefault(m => m.Id == id));
            if (movie == null) return NotFound();  
            return Ok(movie);
        }
        
        [HttpPost] // POST: api/movies
        public ActionResult<InputMovieViewModel> PostMovie(InputMovieViewModel inputModel)
        {
            
            var movie = _context.Add(_mapper.Map<Movie>(inputModel)).Entity;
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = movie.Id }, _mapper.Map<InputMovieViewModel>(inputModel));
        }
        
        [HttpPut("{id}")] // PUT: api/movies/5
        public IActionResult UpdateMovie(int id, EditMovieViewModel editModel)
        {
            try
            {
                var movie = _mapper.Map<Movie>(editModel);
                movie.Id = id;
                
                _context.Update(movie);
                _context.SaveChanges();
                
                return Ok(_mapper.Map<EditMovieViewModel>(movie));
            }
            catch (DbUpdateException)
            {
                if (!MovieExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
        }
        
        [HttpDelete("{id}")] // DELETE: api/movie/5
        public ActionResult<DeleteMovieViewModel> DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();  
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(_mapper.Map<DeleteMovieViewModel>(movie));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}