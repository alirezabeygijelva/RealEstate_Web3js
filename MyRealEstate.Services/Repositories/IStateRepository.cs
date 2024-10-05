using MyRealEstate.DomainClasses.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.Services.Repositories
{
    public interface IStateRepository
    {
        List<State> GetAllState();
        State GetStateById(int stateId);
        void InsertState(State state);
        void UpdateState(State state);
        void DeleteState(int stateId);
        void DeleteState(State state);
        bool StateExists(int stateId);
        void Save();
    }
}
