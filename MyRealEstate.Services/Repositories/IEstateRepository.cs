using MyRealEstate.DomainClasses.Estate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.Services.Repositories
{
    public interface IEstateRepository
    {
        List<Estate> GetAllEstate();
        Estate GetEstateById(int estateId);
        void InsertEstate(Estate estate);
        void UpdateEstate(Estate estate);
        void DeleteEstate(int EstateId);
        void DeleteEstate(Estate estate);
        bool EstateExists(int id);
        void Save();
    }
}
