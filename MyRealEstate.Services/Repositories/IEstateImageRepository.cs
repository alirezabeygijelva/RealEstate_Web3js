using MyRealEstate.DomainClasses.Estate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.Services.Repositories
{
    public interface IEstateImageRepository
    {
        List<EstateImage> GetEstateImageByEstateId(int EstateId);
        void InsertEstateImage(EstateImage estateImage);
    }
}
