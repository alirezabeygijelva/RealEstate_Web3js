using MyRealEstate.DomainClasses.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.Services.Repositories
{
    public interface INeighborhoodRepository
    {
        List<Neighborhood> GetAllNeighborhood();
        Neighborhood GetNeighborhoodById(int neighborhoodId);
        void InsertNeighborhood(Neighborhood neighborhood);
        void UpdateNeighborhood(Neighborhood neighborhood);
        void DeleteNeighborhood(int NeighborhoodId);
        void DeleteNeighborhood(Neighborhood neighborhood);
        bool NeighborhoodExists(int id);
        void Save();
    }
}
