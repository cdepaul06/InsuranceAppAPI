﻿// <auto-generated />
using System;
using InsuranceAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsuranceAppAPI.Migrations
{
    [DbContext(typeof(InsuranceDBContext))]
    [Migration("20240622142804_FixCustomerPolicyModel")]
    partial class FixCustomerPolicyModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InsuranceAppAPI.Models.Automobile", b =>
                {
                    b.Property<int>("AutomobileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutomobileId"));

                    b.Property<int>("CustomerPolicyLineId")
                        .HasColumnType("int");

                    b.Property<int>("MSRP")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("AutomobileId");

                    b.HasIndex("CustomerPolicyLineId");

                    b.ToTable("Automobiles");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.CustomerPolicy", b =>
                {
                    b.Property<int>("CustomerPolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerPolicyId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PolicyEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PolicyPremium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PolicyStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolicyStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PolicyTypeId")
                        .HasColumnType("int");

                    b.HasKey("CustomerPolicyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PolicyStatusId");

                    b.ToTable("CustomerPolicies");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.CustomerPolicyLine", b =>
                {
                    b.Property<int>("CustomerPolicyLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerPolicyLineId"));

                    b.Property<int>("CustomerPolicyId")
                        .HasColumnType("int");

                    b.HasKey("CustomerPolicyLineId");

                    b.HasIndex("CustomerPolicyId");

                    b.ToTable("CustomerPolicyLines");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.Home", b =>
                {
                    b.Property<int>("HomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerPolicyLineId")
                        .HasColumnType("int");

                    b.Property<int>("SquareFootage")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearBuilt")
                        .HasColumnType("int");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("HomeId");

                    b.HasIndex("CustomerPolicyLineId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.Motorcycle", b =>
                {
                    b.Property<int>("MotorcycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MotorcycleId"));

                    b.Property<int>("CustomerPolicyLineId")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MotorcycleId");

                    b.HasIndex("CustomerPolicyLineId");

                    b.ToTable("Motorcycles");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.PolicyStatus", b =>
                {
                    b.Property<int>("PolicyStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyStatusId"));

                    b.Property<string>("PolicyStatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PolicyStatusId");

                    b.ToTable("PolicyStatuses");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.PolicyType", b =>
                {
                    b.Property<int>("PolicyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyTypeId"));

                    b.Property<string>("PolicyTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PolicyTypeId");

                    b.ToTable("PolicyTypes");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserStatusId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.UserStatus", b =>
                {
                    b.Property<int>("UserStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserStatusId"));

                    b.Property<string>("UserStatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserStatusId");

                    b.ToTable("UserStatuses");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"));

                    b.Property<string>("UserTypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.Automobile", b =>
                {
                    b.HasOne("InsuranceAppAPI.Models.CustomerPolicyLine", "CustomerPolicyLine")
                        .WithMany("Automobiles")
                        .HasForeignKey("CustomerPolicyLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicyLine");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.CustomerPolicy", b =>
                {
                    b.HasOne("InsuranceAppAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceAppAPI.Models.PolicyStatus", "PolicyStatus")
                        .WithMany()
                        .HasForeignKey("PolicyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PolicyStatus");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.CustomerPolicyLine", b =>
                {
                    b.HasOne("InsuranceAppAPI.Models.CustomerPolicy", "CustomerPolicy")
                        .WithMany()
                        .HasForeignKey("CustomerPolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicy");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.Home", b =>
                {
                    b.HasOne("InsuranceAppAPI.Models.CustomerPolicyLine", "CustomerPolicyLine")
                        .WithMany("Homes")
                        .HasForeignKey("CustomerPolicyLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicyLine");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.Motorcycle", b =>
                {
                    b.HasOne("InsuranceAppAPI.Models.CustomerPolicyLine", "CustomerPolicyLine")
                        .WithMany("Motorcycles")
                        .HasForeignKey("CustomerPolicyLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicyLine");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.User", b =>
                {
                    b.HasOne("InsuranceAppAPI.Models.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceAppAPI.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStatus");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("InsuranceAppAPI.Models.CustomerPolicyLine", b =>
                {
                    b.Navigation("Automobiles");

                    b.Navigation("Homes");

                    b.Navigation("Motorcycles");
                });
#pragma warning restore 612, 618
        }
    }
}