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
    public class NeighborhoodRepository : INeighborhoodRepository
    {
        private readonly MyRealEstateDbContext _db;
        public NeighborhoodRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }
        public void DeleteNeighborhood(int neighborhoodId)
        {
            var neighborhood = GetNeighborhoodById(neighborhoodId);
            DeleteNeighborhood(neighborhood);
        }

        public void DeleteNeighborhood(Neighborhood neighborhood)
        {
            _db.Entry(neighborhood).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public List<Neighborhood> GetAllNeighborhood()
        {
            return _db.Neighborhoods.Include(p=>p.City).ToList();
        }

        public Neighborhood GetNeighborhoodById(int neighborhoodId)
        {
            return _db.Neighborhoods.Include(p => p.City).FirstOrDefault(p => p.NeighborhoodId == neighborhoodId);
        }

        public void InsertNeighborhood(Neighborhood neighborhood)
        {
            _db.Neighborhoods.Add(neighborhood);
        }

        public bool NeighborhoodExists(int id)
        {
           return _db.Neighborhoods.Any(e => e.NeighborhoodId == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateNeighborhood(Neighborhood neighborhood)
        {
            _db.Entry(neighborhood).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
