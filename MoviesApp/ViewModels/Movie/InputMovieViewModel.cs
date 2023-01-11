using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels
{
    public class InputMovieViewModel
    {
        public string Title { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [OldMovie(1900)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}