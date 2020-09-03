using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Repositories
{
    public interface IAppointmentRepository:ICommon
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentsWithpatient(int id);
        IEnumerable<Appointment> GetAppointmentsByDoctor(int id);
        IEnumerable<Appointment> GetUpcommingAppointments(string docId);
        IEnumerable<Appointment> GetFilteredAppointents(string sortOrder, string currentFilter, string searchString);

        IEnumerable<Appointment> GetTodaysAppointments(int id);
        IEnumerable<Appointment> GetDailyAppointments(DateTime getDate);
        IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel);
        bool ValidateAppointment(DateTime apptDate, int id);
        int CountAppointments(int id);
        Appointment GetAppointment(int id);
        void AddAppointment(Appointment appointment);
    }
}