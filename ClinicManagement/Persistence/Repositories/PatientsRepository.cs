using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ClinicManagement.Persistence.Repositories
{
    public class PatientsRepository : IPatientRepository
    {
        private ApplicationDbContext _db;
        public PatientsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Patient patient)
        {
            _db.Patients.Add(patient);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _db.Patients.Find(id);
            entity.DStatus = false;
            _db.SaveChanges();
        }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public Patient GetPatient(int id)
        {
            return _db.Patients.SingleOrDefault(m => m.DStatus == true && m.Id == id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _db.Patients.Where(m => m.DStatus == true).Include(m=>m.City).OrderByDescending(m => m.DateTime).ToList();
        }
        public IEnumerable<Patient> GetPatients(string sortOrder, string currentFilter, string searchString)
        {
            var patients =  _db.Patients.Where(m => m.DStatus == true).Include(m => m.City).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                patients = patients.Where(m => m.Name.ToLower().Contains(searchString) || m.Token.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "date":
                    patients = patients.OrderByDescending(m => m.DateTime);
                    break;
                case "name_desc":
                    patients = patients.OrderByDescending(m => m.Name);
                    break;
                default:
                    patients = patients.OrderBy(m => m.Name);
                    break;
            }
            return patients.ToList();
        }
        

        public IEnumerable<Patient> GetPatientsByDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetRecentPatients()
        {
            return _db.Patients
                .Where(a => DbFunctions.DiffDays(a.DateTime, DateTime.Now) == 0)
                .Include(c => c.City);
        }

        
    }
}