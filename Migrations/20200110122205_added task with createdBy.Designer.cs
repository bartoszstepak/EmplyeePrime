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
    [Migration("20200110122205_added task with createdBy")]
    partial class addedtaskwithcreatedBy
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

            modelBuilder.Entity("crud_2.Models.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("id");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
