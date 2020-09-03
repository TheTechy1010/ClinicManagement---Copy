using ClinicManagement.Core;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using ClinicManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace ClinicManagement.Persistence
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;

        public IApplicationUserRepository Users { get; private set; }

        public IAppointmentRepository Appointments { get; private set; }

        public IAttendanceRepository Attendances { get; private set; }

        public ICityRepository Cities { get; private set; }

        public IPatientRepository Patients { get; private set; }

        public ISpecializationRepository Specializations { get; private set; }

        public IDoctorRepository Doctors { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Doctors = new DoctorsRepository(_context);
            Cities = new CityRepository(_context);
            Appointments = new AppointmentsRepository(_context);
            Specializations = new SpecializationRepository(_context);
            Patients = new PatientsRepository(_context);
        }
    }
}