using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Core.ViewModel;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Text;

namespace ClinicManagement.Persistence.Repositories
{
    public class AppointmentsRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;
        public AppointmentsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddAppointment(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
        }

        public int CountAppointments(int id)
        {
            return _db.Appointments.Count(m => m.PatientId == id);
        }

        public IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel)
        {
            var result = _db.Appointments.Include(m => m.Doctor).Include(m => m.Patient).AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Name))
                    result = result.Where(m => m.Doctor.Name == searchModel.Name);
                if (!string.IsNullOrWhiteSpace(searchModel.Option))
                {
                    if (searchModel.Option == "ThisMonth")
                    {
                        result = result.Where(x => x.StartDateTime.Year == DateTime.Now.Year && x.StartDateTime.Month == DateTime.Now.Month);
                    }
                    else if (searchModel.Option == "Pending")
                    {
                        result = result.Where(x => x.Status == false);
                    }
                    else if (searchModel.Option == "Approved")
                    {
                        result = result.Where(x => x.Status);
                    }
                }
            }
            return result;

        }

        public Appointment GetAppointment(int id)
        {
            return _db.Appointments.Include(m => m.Patient).Include(m => m.Doctor).SingleOrDefault(m => m.Id == id);
                
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _db.Appointments.Where(m=>m.DStatus==true)
                .Include(p => p.Patient)
                .Include(d => d.Doctor).OrderByDescending(m => m.StartDateTime)
                .ToList();
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctor(int id)
        {
            return _db.Appointments.Where(a => a.DoctorId == id)
                .Include(m => m.Patient).OrderByDescending(m => m.StartDateTime)
                .Include(m => m.Doctor)
                .ToList();
        }

        public IEnumerable<Appointment> GetAppointmentsWithpatient(int id)
        {
            return _db.Appointments.Where(a => a.PatientId == id)
                .Include(m => m.Patient)
                .Include(m => m.Doctor)
                .ToList();
        }

        public IEnumerable<Appointment> GetDailyAppointments(DateTime getDate)
        {
            return _db.Appointments.Where(a => DbFunctions.DiffDays(a.StartDateTime, getDate) == 0 && a.DStatus==true)
                .Include(m => m.Patient).OrderByDescending(m => m.StartDateTime)
                .Include(m => m.Doctor)
                .ToList();
        }
        public IEnumerable<Appointment> GetTodaysAppointmentsByPatient(int patientId)
        {
            var today = DateTime.Now.Date;
            return _db.Appointments.Where(a => a.PatientId == patientId && a.DStatus==true)
                .Include(m => m.Patient).OrderByDescending(m => m.StartDateTime == today)
                .Include(m => m.Doctor)
                .ToList();
        }
        public IEnumerable<Appointment> GetTodaysAppointmentsByDoctor(int docId)
        {
            return _db.Appointments.Where(a => a.DoctorId == docId && a.DStatus==true)
                .Include(m => m.Patient).OrderByDescending(m => m.StartDateTime)
                .Include(m => m.Doctor)
                .ToList();
        }
        public IEnumerable<Appointment> GetFilteredAppointents(string sortOrder, string currentFilter, string searchString)
        {
            var appts = _db.Appointments.Include(m => m.Patient).Include(m => m.Doctor).Where(m => m.DStatus == true).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                appts = appts.Where(m => m.Patient.Name.ToLower().Contains(searchString) || m.Patient.Token.ToLower().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "date":
                    appts = appts.OrderByDescending(m => m.StartDateTime);
                    break;
                case "name_desc":
                    appts = appts.OrderByDescending(m => m.Patient.Name);
                    break;
                case "only_pending":
                    appts = appts.Where(m => m.AppointmentStatus == AppointmentStatus.Pending).OrderByDescending(m => m.Patient.Name);
                    break;
                case "only_appproved":
                    appts = appts.Where(m => m.AppointmentStatus == AppointmentStatus.Approved).OrderByDescending(m => m.Patient.Name);
                    break;
                case "only_rejected":
                    appts = appts.Where(m=>m.AppointmentStatus == AppointmentStatus.Rejected).OrderByDescending(m => m.Patient.Name);
                    break;
                default:
                    appts = appts.OrderBy(m => m.Patient.Name);
                    break;
            }
            return appts.ToList();
        }

        public IEnumerable<Appointment> GetTodaysAppointments(int id)
        {
            var today = DateTime.Now.Date;
            return _db.Appointments.Where(m => m.StartDateTime == today && m.DoctorId == id && m.DStatus==true)
           .Include(m => m.Patient)
           .Include(m => m.Doctor)
           .ToList();
        }

        public IEnumerable<Appointment> GetUpcommingAppointments(string docId)
        {
            var today = DateTime.Now.Date;
            return _db.Appointments
                .Where(c => c.Doctor.PhysicianId == docId && c.DStatus==true&& c.StartDateTime >= today)
                .Include(p => p.Patient).OrderByDescending(d => d.StartDateTime)
                .ToList();

        }

        public bool ValidateAppointment(DateTime apptDate, int id)
        {
            var isAvailable = _db.Appointments.Any(m => DbFunctions.DiffHours(m.StartDateTime, apptDate) == 1
            || DbFunctions.DiffHours(DbFunctions.AddHours(m.StartDateTime, -1), apptDate) == 1
            || m.StartDateTime == apptDate && m.DoctorId == id && m.DStatus==true);
            return isAvailable;
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}