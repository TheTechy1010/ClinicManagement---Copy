using ClinicManagement.Controllers;
using ClinicManagement.Core.Helpers;
using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Core.ViewModel
{
    public class PatientFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Gender Sex { get; set; }
        [Required]
        [ValidDate]
        public string BirthDate { get; set; }


        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public byte City { get; set; }

        public DateTime Date { get; set; }

        

        public DateTime GetBirthDate()
        {
            //TODO: Validate BirthDate 

            return DateTime.Parse(string.Format("{0}", BirthDate));
            //return DateTime.ParseExact(BirthDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
        public IEnumerable<City> Cities { get; set; }

        public string Action 
        { 
            get 
            {
                Expression<Func<PatientsController, ActionResult>> update = (c => c.UpdatePatient(this));
                Expression<Func<PatientsController, ActionResult>> create = (c => c.AddPatient(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            } 
        }
        public string Heading
        {
            get
            {
                return  (Id != 0) ? "Update patient" : "Register Patient";
            }
            set { }
        }
        #region ForDropDownList
        public IEnumerable<SelectListItem> CityList
        {
            get 
            {
                return ClinicMgtHelpers.CityToSelectList();
            }
        }
        public IEnumerable<SelectListItem> GendersList
        {
            get { return ClinicMgtHelpers.GenderToSelectList(); }
            set { }
        }
        #endregion
    }
}