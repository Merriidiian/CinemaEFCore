using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Dto;

namespace MoviesApp.Services
{
    public class MovieService:IMovieService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;
        
        public MovieService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public MovieDto GetMovie(int id)
        {
            return _mapper.Map<MovieDto>(_context.Movies.FirstOrDefault(m => m.Id == id));
        }

        public IEnumerable<MovieDto> GetAllMovies()
        {
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(_context.Movies.ToList());
        }

        public MovieDto UpdateMovie(MovieDto movieDto)
        {
            if (movieDto.Id == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }
            
            try
            {
                var movie = _mapper.Map<Movie>(movieDto);
                
                _context.Update(movie);
                _context.SaveChanges();
                
                return _mapper.Map<MovieDto>(movie);
            }
            catch (DbUpdateException)
            {
                if (!MovieExists((int) movieDto.Id))
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
                else
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
            }
        }

        public MovieDto AddMovie(MovieDto movieDto)
        {
            var movie = _context.Add(_mapper.Map<Movie>(movieDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<MovieDto>(movie);
        }

        public MovieDto DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            
            return _mapper.Map<MovieDto>(movie);
        }
        
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}