using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.ViewModel
{
    public class ValidTime:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime time;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                                                  "HH:mm",
                                                  CultureInfo.CurrentCulture,
                                                  DateTimeStyles.None,
                                                  out time);
            if (isValid)
                return ValidationResult.Success;
            return new ValidationResult("Given time is not valid");
        }

        
    }
}