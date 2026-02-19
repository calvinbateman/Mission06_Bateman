using System;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Bateman.Models
{
    public class CurrentYearAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;

                if (year >= 1888 && year <= currentYear)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"Year must be between 1888 and {DateTime.Now.Year}.");
        }
    }
}