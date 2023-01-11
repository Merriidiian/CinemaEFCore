using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.Dto
{
    public class MovieDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? Id { get; set; }
        
        [Required]
        [StringLength(32,ErrorMessage = "Title length can't be more than 32.")]
        public string Title { get; set; }
        
        
        [Required]
        [DataType(DataType.Date)]
        [OldMovie(1900)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public string Genre { get; set; }
        
        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
    }
}