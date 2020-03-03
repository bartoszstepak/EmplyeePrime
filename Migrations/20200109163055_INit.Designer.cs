﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crud_2.Models;

namespace crud_2.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20200109163055_INit")]
    partial class INit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("crud_2.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(MAX)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("secondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("crud_2.Models.Login", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("id");

                    b.ToTable("Logins");
                });
#pragma warning restore 612, 618
        }
    }
}
