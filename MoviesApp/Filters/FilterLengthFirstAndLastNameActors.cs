using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesApp.Filters
{
    public class FilterLengthFirstAndLastNameActors: Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ageMin = DateTime.Parse("01.01.2019");
            var ageMax = DateTime.Parse("01.01.1924");
            var ageActor = DateTime.Parse(context.HttpContext.Request.Form["BirthDate"]);
            if (ageActor > ageMin || ageActor < ageMax)
            {
                context.Result = new BadRequestResult();
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}