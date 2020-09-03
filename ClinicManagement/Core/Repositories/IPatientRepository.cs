using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Repositories
{
    public interface IPatientRepository:ICommon
    {
        IEnumerable<Patient> GetPatients();
        IEnumerable<Patient> GetPatients(string sortOrder, string currentFilter, string searchString);
        IEnumerable<Patient> GetRecentPatients();
        //IEnumerable<Patient> GetPatientByToken(string searchTerm = null);
        Patient GetPatient(int id);
        void Add(Patient patient);
        
        IEnumerable<Patient> GetPatientsByDoctor(int id);
    }
}