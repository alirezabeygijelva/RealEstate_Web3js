using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRealEstate.Services.Services
{
    public class EstateImageRepository : IEstateImageRepository
    {
        private readonly MyRealEstateDbContext _db;
        public EstateImageRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }
        public List<EstateImage> GetEstateImageByEstateId(int EstateId)
        {
            return _db.EstateImages.Where(p => p.EstateId == EstateId).ToList();
        }

        public void InsertEstateImage(EstateImage estateImage)
        {
            _db.EstateImages.Add(estateImage);
        }
    }
}
