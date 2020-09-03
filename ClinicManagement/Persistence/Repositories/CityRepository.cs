using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;
        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddCity(City city)
        {
            var newCityId = _db.Cities.Count() + 1;
            city.Id = (byte)newCityId;
            _db.Cities.Add(city);
            _db.SaveChanges();
        }

        public IEnumerable<City> GetCities()
        {
            return _db.Cities.ToList().OrderByDescending(m => m.Id);
        }

        public City GetCity(int id)
        {
            return _db.Cities.Find(id);
            throw new HttpException(404, "City Not Found");
        }
        public void Complete()
        {
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var city = _db.Cities.Find(id);
            _db.Cities.Remove(city);
            _db.SaveChanges();
        }
    }
}