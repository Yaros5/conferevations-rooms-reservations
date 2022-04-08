﻿// <auto-generated />
using Hosp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hosp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220407140101_DoctorBugStringFlip")]
    partial class DoctorBugStringFlip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Hosp.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FinishHour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HospitalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickNameFlip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Profesion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StartHour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("HospitalId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Hosp.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FinishWork")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameHospital")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StartWork")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Hosp.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Hosp.Models.Doctor", b =>
                {
                    b.HasOne("Hosp.Models.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("Hosp.Models.Hospital", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}