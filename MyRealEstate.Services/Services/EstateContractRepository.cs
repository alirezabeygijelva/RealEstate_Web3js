using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;
using RealStateWebAPI.Services;

namespace MyRealEstate.Services.Services
{
   public class EstateContractRepository :IEstateContractRepository
    {
        private readonly MyRealEstateDbContext _db;

        public EstateContractRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }


        public List<EstateContract> GetEstateContracts(int estateId)
        {
            return _db.EstateContracts.Where(p=>p.EstateId == estateId).ToList();
        }

        public EstateContract GetEstateContract(int estateContractId)
        {
            return _db.EstateContracts.FirstOrDefault(p => p.EstateContractId == estateContractId);
        }

        public void InsertEstateContract(EstateContract estateContract)
        {
            _db.EstateContracts.Add(estateContract);
          
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
