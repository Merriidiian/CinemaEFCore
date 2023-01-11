using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Internal.Mappers;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class AttributeLenghtNameAndSurname : ValidationAttribute
    {

        public string GetErrorMessage() =>
            $"The length of the first or last name can only be longer than 3 characters.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int lenght = value.ToString().Length;
            if (lenght <= 4)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}