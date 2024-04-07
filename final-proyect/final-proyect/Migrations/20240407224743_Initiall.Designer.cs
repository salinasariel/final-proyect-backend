﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using final_proyect.Data;

#nullable disable

namespace final_proyect.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240407224743_Initiall")]
    partial class Initiall
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.28");

            modelBuilder.Entity("final_proyect_backend.Models.Applications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AplicationState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnterpriseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("final_proyect_backend.Models.Offers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CareerMinimumAge")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareersInterested")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnterpriseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InitDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("InmediteIncorporation")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Intern")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InternTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("OfferState")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SkillsRequired")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("final_proyect_backend.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UserState")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Users");
                });

            modelBuilder.Entity("final_proyect_backend.Models.Admins", b =>
                {
                    b.HasBaseType("final_proyect_backend.Models.Users");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkArea")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Admins");
                });

            modelBuilder.Entity("final_proyect_backend.Models.Enterprises", b =>
                {
                    b.HasBaseType("final_proyect_backend.Models.Users");

                    b.Property<string>("AboutCompany")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Enterprises_City");

                    b.Property<string>("CompanyAbout")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeesQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnterpriseType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LegalAbout")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WebPage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Enterprises");
                });

            modelBuilder.Entity("final_proyect_backend.Models.Students", b =>
                {
                    b.HasBaseType("final_proyect_backend.Models.Users");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CareerAge")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CoursesFile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Cuit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CvFile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Dni")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnglishLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FileNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HighSchoolFile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InitDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
