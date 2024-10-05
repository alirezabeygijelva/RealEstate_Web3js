using Microsoft.EntityFrameworkCore;
using MyRealEstate.DomainClasses.Admin;
using MyRealEstate.DomainClasses.Estate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.DataLayer.Context
{
    public class MyRealEstateDbContext:DbContext
    {
        public MyRealEstateDbContext(DbContextOptions<MyRealEstateDbContext> options):base(options)
        {

        }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateImage> EstateImages { get; set; }
        public DbSet<EstateStatus> EstateStatuses { get; set; }
        public DbSet<EstateContract> EstateContracts { get; set; }
        public DbSet<RequestEstate> RequestEstates { get; set; }

    }
}
