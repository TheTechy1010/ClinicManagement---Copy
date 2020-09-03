using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Repositories
{
    public interface ISpecializationRepository:ICommon
    {
        IEnumerable<Specialization> GetSpecializations();
        void AddSpecialization(Specialization spec);
        Specialization GetSpecialization(int id);
    }
}