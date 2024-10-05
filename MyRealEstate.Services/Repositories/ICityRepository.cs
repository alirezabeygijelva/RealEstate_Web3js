using MyRealEstate.DomainClasses.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.Services.Repositories
{
    public interface ICityRepository
    {
        List<City> GetAllCity();
        City GetCityById(int cityId);
        void InsertCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int CityId);
        void DeleteCity(City city);
        bool CityExists(int id);
        void Save();
    }
}
