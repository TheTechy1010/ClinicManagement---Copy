using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class ApplicationUserConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(m => m.Sex).IsRequired().HasMaxLength(20);
            Property(m => m.Status).IsRequired();
        }
    }
}