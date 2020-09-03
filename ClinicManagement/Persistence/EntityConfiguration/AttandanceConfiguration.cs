using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            Property(p => p.PatientId).IsRequired();
            Property(p => p.ClinicRemarks).IsRequired();
            Property(p => p.Diagnosis).IsRequired().HasMaxLength(255);
            Property(p => p.Therapy).IsRequired();
            Property(m => m.DStatus).IsRequired();
        }
    }
}