using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.Repositories
{
    public class AttandancesRepository : IAttendanceRepository
    {
        private ApplicationDbContext _db;
        public AttandancesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Attendance attendance)
        {
            _db.Attendances.Add(attendance);
            _db.SaveChanges();
        }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public int CountAttendances(int patid)
        {
            return _db.Attendances.Where(m => m.DStatus == true && m.PatientId == patid).Count();
        }

        public void Delete(int id)
        {
            var attd = _db.Attendances.Find(id);
            attd.DStatus = false;
            _db.SaveChanges();
        }

        public IEnumerable<Attendance> GetAttandences()
        {
            return _db.Attendances.Where(m => m.DStatus).ToList();
        }

        public IEnumerable<Attendance> GetAttendance(int id)
        {
            return _db.Attendances.Where(m => m.DStatus == true && m.PatientId == id).ToList();
        }

        public IEnumerable<Attendance> GetPatientAttandences(string searchTerm = null)
        {
            var data = _db.Attendances.Where(m => m.DStatus == true).Include(n => n.Patient);
            if (!string.IsNullOrWhiteSpace(searchTerm))
                data = data.Where(m => m.Patient.Token.Contains(searchTerm));
            return data.ToList();
                
        }
    }
}