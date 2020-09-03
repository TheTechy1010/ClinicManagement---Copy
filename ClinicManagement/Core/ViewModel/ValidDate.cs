using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.ViewModel
{
    public class ValidDate:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);
            if (isValid)
                return ValidationResult.Success;
            return new ValidationResult("Given date is not valid");
        }
    }
    public class ValidateCity : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new ApplicationDbContext();
            var name = value.ToString();
            var isExist = db.Cities.Any(m => m.Name == name);
            if (isExist)
            {
                return new ValidationResult("City already exists in the records.");
            }
            db.Dispose();
            return ValidationResult.Success;
        }
    }
}