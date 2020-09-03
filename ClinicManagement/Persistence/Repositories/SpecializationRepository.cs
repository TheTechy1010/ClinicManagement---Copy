using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private ApplicationDbContext _db;
        public SpecializationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddSpecialization(Specialization spec)
        {
            _db.Specializations.Add(spec);
            _db.SaveChanges();
        }

        public Specialization GetSpecialization(int id)
        {
            return _db.Specializations.Find(id);
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            return _db.Specializations.Where(m=>m.DStatus==true).OrderByDescending(m => m.Id).ToList();
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