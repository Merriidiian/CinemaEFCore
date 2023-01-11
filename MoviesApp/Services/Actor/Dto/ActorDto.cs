using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.Actor.Dto;

public class ActorDto
{
    public int? Id { get; set; }
    
    [Required]
    [AttributeLenghtNameAndSurname]
    public string Name { get; set; }
    
    [Required]
    [AttributeLenghtNameAndSurname]
    public string Surname { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
}