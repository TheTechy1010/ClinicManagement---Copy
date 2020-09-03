using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Repositories
{
    public interface IAttendanceRepository:ICommon
    {
        IEnumerable<Attendance> GetAttandences();
        IEnumerable<Attendance> GetAttendance(int id);
        IEnumerable<Attendance> GetPatientAttandences(string searchTerm = null);
        int CountAttendances(int id);
        void Add(Attendance attendance);
    }
}