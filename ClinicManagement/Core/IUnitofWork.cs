using ClinicManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core
{
    public interface IUnitofWork
    {
        IApplicationUserRepository Users { get;}
        IAppointmentRepository Appointments { get; }
        IAttendanceRepository Attendances { get; }
        ICityRepository Cities { get; }
        IPatientRepository Patients { get; }
        ISpecializationRepository Specializations { get; }
        IDoctorRepository Doctors { get; }

        void Complete();
    }
}
