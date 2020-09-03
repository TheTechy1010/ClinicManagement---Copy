using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Core.ViewModel
{
    public class AppointmentFormViewModel
    {
        public int Id { get; set; }

        [Required]
        
        public string Date { get; set; }

        [Required]
        
        public string Time { get; set; }


        [Required]
        public string Detail { get; set; }

        [Required]
        public bool Status { get; set; }
        
        public AppointmentStatus AppointmentStatus { get { return AppointmentStatus.Pending; } }
        [Required]
        public int Patient { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

        [Required]
        public int Doctor { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }
        public string Heading { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<SelectListItem> DoctorsList { get; set; }
        public DateTime GetStartDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

    }
}