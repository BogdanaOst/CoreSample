﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BinaryCoreSample.Models;

namespace BinaryCoreSample.Migrations
{
    [DbContext(typeof(HouseContext))]
    [Migration("20170803152618_fixedMissprint")]
    partial class fixedMissprint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BinaryCoreSample.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<int>("Floors");

                    b.Property<int>("NumberOfHomemates");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });
        }
    }
}
