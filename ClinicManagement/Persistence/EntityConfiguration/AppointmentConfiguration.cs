using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class AppointmentConfiguration:EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfiguration()
        {
            Property(m => m.PatientId).IsRequired();
            Property(m => m.DoctorId).IsRequired();
            Property(m => m.Detail).IsRequired();
            Property(m => m.Status).IsRequired();
            Property(m => m.StartDateTime).IsRequired();
            Property(m => m.Status).IsRequired();
        }
    }
}