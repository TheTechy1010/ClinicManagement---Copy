using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace ClinicManagement.Persistence.Repositories
{
    public class DoctorsRepository : IDoctorRepository,ICommon
    {
        private readonly ApplicationDbContext _db;
        [InjectionConstructor]
        public DoctorsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
        }

        public IEnumerable<Doctor> GetAvailableDoctors()
        {
            return _db.Doctors.Where(m => m.IsAvailable == true)
                .Include(m=>m.Physician)
                .Include(m=>m.Specialization)
                .ToList();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _db.Doctors
                .Include(m=>m.Physician)
                .Include(m=>m.Specialization).OrderByDescending(m => m.Id)
                .ToList();
        }

        public Doctor GetDoctor(int id)
        {
            return _db.Doctors
                .Include(m => m.Physician)
                .Include(m => m.Specialization)
                .SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Doctor> GetDoctors(string sortOrder, string currentFilter, string searchString)
        {
            var doctors = _db.Doctors.Where(m => m.DStatus == true).Include(m => m.Specialization).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                doctors = doctors.Where(m => m.Name.ToLower().Contains(searchString));
            }
            switch (sortOrder)
            {
                //case "date":
                //    doctors = doctors.OrderByDescending(m => m.);
                //    break;
                case "name_desc":
                    doctors = doctors.OrderByDescending(m => m.Name);
                    break;
                default:
                    doctors = doctors.OrderBy(m => m.Name);
                    break;
            }
            return doctors.ToList();
        }

        public Doctor GetProfile(string userId)
        {
            return _db.Doctors
                .Include(m => m.Physician)
                .Include(m => m.Specialization)
                .SingleOrDefault(m => m.PhysicianId == userId);
        }

        public IEnumerable<SelectListItem> DoctorsToSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var doctors = this.GetAvailableDoctors();
            foreach (var item in doctors)
            {
                SelectListGroup group = new SelectListGroup { Disabled = true, Name = item.Specialization.Name };
                items.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString(), Group = group });
            }
            return items;
        }

        public void Delete(int id)
        {
            var entity = _db.Doctors.Find(id);
            entity.DStatus = false;
            _db.SaveChanges();
        }

        public void Complete()
        {
            _db.SaveChanges();
        }
    }
}