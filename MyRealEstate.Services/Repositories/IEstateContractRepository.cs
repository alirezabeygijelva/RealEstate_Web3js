using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRealEstate.DomainClasses.Estate;

namespace MyRealEstate.Services.Repositories
{
    public interface IEstateContractRepository
    {
        List<EstateContract> GetEstateContracts(int estateId);
        EstateContract GetEstateContract(int estateContractId);
        void InsertEstateContract(EstateContract estateContract);
        void Save();
    }
}
