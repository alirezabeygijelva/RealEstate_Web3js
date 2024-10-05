﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRealEstate.DataLayer.Context;

namespace MyRealEstate.DataLayer.Migrations
{
    [DbContext(typeof(MyRealEstateDbContext))]
    [Migration("13980311133940_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyRealEstate.DomainClasses.Admin.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("StateId");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Admin.Neighborhood", b =>
                {
                    b.Property<int>("NeighborhoodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("NeighborhoodName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("NeighborhoodId");

                    b.HasIndex("CityId");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Admin.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Estate.Estate", b =>
                {
                    b.Property<int>("EstateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Area");

                    b.Property<short>("ConstructionYear");

                    b.Property<bool>("Enable");

                    b.Property<string>("EstateLogo");

                    b.Property<int>("EstateStatusId");

                    b.Property<int>("NeighborhoodId");

                    b.Property<string>("Note");

                    b.Property<long>("Price");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("smalldatetime");

                    b.Property<byte>("RoomNo");

                    b.Property<string>("Title")
                        .HasMaxLength(500);

                    b.HasKey("EstateId");

                    b.HasIndex("EstateStatusId");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Estates");
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Estate.EstateImage", b =>
                {
                    b.Property<int>("EstateImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstateId");

                    b.Property<string>("EstateImg");

                    b.HasKey("EstateImageId");

                    b.HasIndex("EstateId");

                    b.ToTable("EstateImages");
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Estate.EstateStatus", b =>
                {
                    b.Property<int>("EstateStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("EstateStatusId");

                    b.ToTable("EstateStatuses");
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Admin.City", b =>
                {
                    b.HasOne("MyRealEstate.DomainClasses.Admin.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Admin.Neighborhood", b =>
                {
                    b.HasOne("MyRealEstate.DomainClasses.Admin.City", "City")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Estate.Estate", b =>
                {
                    b.HasOne("MyRealEstate.DomainClasses.Estate.EstateStatus", "EstateStatus")
                        .WithMany("Estates")
                        .HasForeignKey("EstateStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyRealEstate.DomainClasses.Admin.Neighborhood", "Neighborhood")
                        .WithMany("Estates")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyRealEstate.DomainClasses.Estate.EstateImage", b =>
                {
                    b.HasOne("MyRealEstate.DomainClasses.Estate.Estate", "Estate")
                        .WithMany("EstateImages")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
