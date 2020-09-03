using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Core.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors();
        IEnumerable<Doctor> GetDoctors(string sortOrder, string currentFilter, string searchString);
        IEnumerable<Doctor> GetAvailableDoctors();
        IEnumerable<SelectListItem> DoctorsToSelectList();
        Doctor GetDoctor(int id);
        Doctor GetProfile(string userId);
        void Add(Doctor doctor);
        void Delete(int docId);
    }
}