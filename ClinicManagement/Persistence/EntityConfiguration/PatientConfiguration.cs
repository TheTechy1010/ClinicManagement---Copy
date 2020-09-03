using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class PatientConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
            //Property(p => p.CityId).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(255);
            Property(p => p.Phone).IsRequired().HasMaxLength(255);
            Property(p => p.Address).IsRequired().HasMaxLength(255);
            Property(p => p.BirthDate).IsRequired();
            Property(p => p.Token).IsRequired();
            HasMany(p => p.Appointments)
                .WithRequired(a => a.Patient)
                .WillCascadeOnDelete(false);
            Property(m => m.DStatus).IsRequired();
        }
    }
}