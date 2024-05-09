﻿// <auto-generated />
using System;
using ETLProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETLProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508181213_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ETLProject.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DOLocationID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DropoffDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("FareAmount")
                        .HasColumnType("float");

                    b.Property<string>("PULocationID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PickupDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("StoreAndFwdFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TipAmount")
                        .HasColumnType("float");

                    b.Property<double>("TripDistance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
