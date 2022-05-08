using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    public class MinKezdo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var szerzodes = (Szerzodes)validationContext.ObjectInstance;

            if (szerzodes.BerlesKezdoIdopont >= DateTime.Today.Date)
                return ValidationResult.Success;
            else    
                return new ValidationResult("A bérlés kezdő dátuma nem lehet korábbi, mint a mai nap!");
        }
    }
}