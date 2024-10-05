using Microsoft.EntityFrameworkCore;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Admin;
using MyRealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRealEstate.Services.Services
{
    public class CityRepository : ICityRepository
    {
        private readonly MyRealEstateDbContext _db;
        public CityRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }

        public bool CityExists(int id)
        {
            return _db.Cities.Any(p => p.CityId == id);
        }

        public void DeleteCity(int CityId)
        {
            var city = GetCityById(CityId);
            DeleteCity(city);
        }

        public void DeleteCity(City city)
        {
            _db.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public List<City> GetAllCity()
        {
            return _db.Cities.Include(p=>p.State).ToList();
        }

        public City GetCityById(int cityId)
        {
            return _db.Cities.Find(cityId);
        }

        public void InsertCity(City city)
        {
            _db.Cities.Add(city);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            _db.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
