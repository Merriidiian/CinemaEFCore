namespace MoviesApp.ViewModels.Actor;
using System;
using System.ComponentModel.DataAnnotations;

public class InputActorViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
   [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}