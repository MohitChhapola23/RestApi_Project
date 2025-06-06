﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewRestApiProject.DataContext;

#nullable disable

namespace NewRestApiProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250529143014_initialization")]
    partial class initialization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewRestApiProject.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 10,
                            DepartmentName = ".Net"
                        },
                        new
                        {
                            DepartmentId = 20,
                            DepartmentName = "HR"
                        });
                });

            modelBuilder.Entity("NewRestApiProject.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1001,
                            DateOfBirth = new DateTime(1985, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 10,
                            Email = "rai.verma@sircltech.com",
                            FirstName = "Rai",
                            LastName = "Singh",
                            PhotoPath = "/images/rai.jpg",
                            Sex = 0
                        },
                        new
                        {
                            EmployeeId = 1002,
                            DateOfBirth = new DateTime(1986, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 20,
                            Email = "naresh@sircltech.com",
                            FirstName = "Naresh",
                            LastName = "Verma",
                            PhotoPath = "/images/naresh.jpg",
                            Sex = 0
                        },
                        new
                        {
                            EmployeeId = 1003,
                            DateOfBirth = new DateTime(1982, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 10,
                            Email = "rvinod@sircltech.com",
                            FirstName = "Vinod",
                            LastName = "Kumar",
                            PhotoPath = "/images/vinod.jpg",
                            Sex = 0
                        },
                        new
                        {
                            EmployeeId = 1004,
                            DateOfBirth = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 10,
                            Email = "rishi@sircltech.com",
                            FirstName = "Rishi",
                            LastName = "Kumar",
                            PhotoPath = "/images/rishi.jpg",
                            Sex = 0
                        });
                });

            modelBuilder.Entity("NewRestApiProject.Models.Employee", b =>
                {
                    b.HasOne("NewRestApiProject.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
