using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;

namespace MyRealEstate.Services.Services
{
    public  class RequestEstateRepository: IRequestEstateRepository
    {
        private readonly MyRealEstateDbContext _db;
        public RequestEstateRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }
        public List<RequestEstate> GetAllRequestEstate(int estateId)
        {
            return _db.RequestEstates.Where(p => p.EstateId == estateId).ToList();
        }

        public RequestEstate GetRequestEstateById(int requestStateId)
        {
            return _db.RequestEstates.FirstOrDefault(p => p.RequestEstateId == requestStateId);
        }

        public void InsertRequestEstate(RequestEstate requestEstate)
        {
            _db.RequestEstates.Add(requestEstate);
        }

        public void UpdateRequestEstate(RequestEstate requestEstate)
        {
            _db.Entry(requestEstate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DeleteRequestEstate(int requestStateId)
        {
            var requestState = GetRequestEstateById(requestStateId);
            DeleteRequestEstate(requestState);
        }

        public void DeleteRequestEstate(RequestEstate requestEstate)
        {
            _db.Entry(requestEstate).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public bool RequestEstateExists(int requestStateId)
        {
            return _db.RequestEstates.Any(e => e.RequestEstateId == requestStateId);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
