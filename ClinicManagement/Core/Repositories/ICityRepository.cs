using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Repositories
{
    public interface ICityRepository:ICommon
    {
        IEnumerable<City> GetCities();
        void AddCity(City city);
        City GetCity(int id);
    }
}