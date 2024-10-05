using MyRealEstate.DomainClasses.Estate;
using System;
using System.Collections.Generic;
using System.Text;
using MyRealEstate.DomainClasses.Admin;

namespace MyRealEstate.Services.Repositories
{
    public interface IRequestEstateRepository
    {
        List<RequestEstate> GetAllRequestEstate(int estateId);
        RequestEstate GetRequestEstateById(int requestStateId);
        void InsertRequestEstate(RequestEstate requestEstate);
        void UpdateRequestEstate(RequestEstate requestEstate);
        void DeleteRequestEstate(int requestStateId);
        void DeleteRequestEstate(RequestEstate requestEstate);
        bool RequestEstateExists(int requestStateId);
        void Save();
    }
}
