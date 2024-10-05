using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateWebAPI.Services
{
    public interface IRealEstateService
    {
        Task<int> GetBalance(string address);
        Task<string> AddAccount(string password);
        Task<Contract> GetContract(string name);
        Task<bool> AddEstateContract(uint ecCode, string addressBuyer, string addressSeller, uint amount);
        Task<bool> Accept(uint ecCode);
        Task<string> GetOwner(uint ecCode);
        void SetAccount(string accountAddress, string accountPassword);
    }
}
