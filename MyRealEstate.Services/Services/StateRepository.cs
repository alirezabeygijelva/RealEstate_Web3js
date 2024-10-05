using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Admin;
using MyRealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRealEstate.Services.Services
{
    public class StateRepository : IStateRepository
    {
        private readonly MyRealEstateDbContext _db;
        public StateRepository(MyRealEstateDbContext db)
        {
            _db = db;
        }
        public void DeleteState(int stateId)
        {
            var state = GetStateById(stateId);
            DeleteState(state);
        }

        public void DeleteState(State state)
        {
            _db.Entry(state).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public List<State> GetAllState()
        {
            return _db.States.ToList();
        }

        public State GetStateById(int stateId)
        {
            return _db.States.Find(stateId);
        }

        public void InsertState(State state)
        {
            _db.States.Add(state);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public bool StateExists(int stateId)
        {
            return _db.States.Any(p => p.StateId == stateId);
        }

        public void UpdateState(State state)
        {
            _db.Entry(state).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
