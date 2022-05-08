using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    public class MinZaro : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var szerzodes = (Szerzodes)validationContext.ObjectInstance;

            if (szerzodes.BerlesZaroIdopont >= DateTime.Today.Date && szerzodes.BerlesZaroIdopont.Day - szerzodes.BerlesKezdoIdopont.Day >= 1)
                return ValidationResult.Success;
            else
                return new ValidationResult("A bérlés záró dátuma nem lehet korábbi, mint a mai nap!\nA minimális kölcsönzési idő 1 nap!");
        }
    }
}