using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ClinicManagement.Persistence.EntityConfiguration
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255);
            Property(m => m.DStatus).IsRequired();
        }
    }
}