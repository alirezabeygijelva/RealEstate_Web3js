using Microsoft.EntityFrameworkCore;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRealEstate.Services.Services
{
    public class EstateRepository : IEstateRepository
    {
        private readonly MyRealEstateDbContext _db;
        public EstateRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }
        public void DeleteEstate(int estateId)
        {
            var estate = GetEstateById(estateId);
            DeleteEstate(estate);
        }

        public void DeleteEstate(Estate estate)
        {
            _db.Entry(estate).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public bool EstateExists(int id)
        {
            return _db.Estates.Any(e => e.EstateId == id);
        }

        public List<Estate> GetAllEstate()
        {
            return _db.Estates.Include(p=>p.Neighborhood).ToList();
        }

        public Estate GetEstateById(int estateId)
        {
            return _db.Estates.Include(p => p.Neighborhood).FirstOrDefault(p=>p.EstateId == estateId);
        }

        public void InsertEstate(Estate estate)
        {
            _db.Estates.Add(estate);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateEstate(Estate estate)
        {
            _db.Entry(estate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
