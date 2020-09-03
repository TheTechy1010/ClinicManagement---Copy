using ClinicManagement.Core.Models;
using ClinicManagement.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Core.Helpers
{
    public static class ClinicMgtHelpers
    {
        public static IEnumerable<SelectListItem> GenderToSelectList()
        {
            var genderItems = EnumHelpers.ToSelectList(typeof(Gender)).ToList();
            genderItems.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return genderItems;
        }
        public static IEnumerable<SelectListItem> ApptStatusToSelectList()
        {
            var apptStatus = EnumHelpers.ToSelectList(typeof(AppointmentStatus)).ToList();
            apptStatus.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return apptStatus;
        }
        public static IEnumerable<SelectListItem> CityToSelectList()
        {
            List<City> cities = new ApplicationDbContext().Cities.ToList();
            var cityItems = EnumHelpers.ToSelectList(cities).ToList();
            cityItems.Insert(0, new SelectListItem { Text = "--Select--", Value = "" });
            return cityItems;
        }
       
    }

    public static class ExtClass
    {
        public static string ToPascal(this String word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }
    }
}