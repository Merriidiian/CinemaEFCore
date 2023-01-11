using MoviesApp.Filters;

namespace MoviesApp.ViewModels.Actor;
using System;
using System.ComponentModel.DataAnnotations;

public class InputActorViewModel
{
    [AttributeLenghtNameAndSurname]
    public string Name { get; set; }
    [AttributeLenghtNameAndSurname]
    public string Surname { get; set; }
    
   [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}