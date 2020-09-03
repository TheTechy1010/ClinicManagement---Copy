using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
            Property(d => d.PhysicianId).IsRequired();
            Property(d => d.SpecializationId).IsRequired();
            Property(d => d.Name).IsRequired().HasMaxLength(255);
            Property(d => d.Phone).IsRequired();
            Property(m => m.DStatus).IsRequired();
        }
    }
}