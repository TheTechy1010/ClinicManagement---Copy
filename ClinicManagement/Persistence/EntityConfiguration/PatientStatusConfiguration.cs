using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class PatientStatusConfiguration : EntityTypeConfiguration<PatientStatus>
    {
        public PatientStatusConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}