﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotCoreWebAPI.Models2
{
    /// <summary>
    /// AdventureWorksContext
    /// </summary>
    public partial class AdventureWorksContext : DbContext
    {
        /// <summary>
        /// AdventureWorksContext
        /// </summary>
        /// <param name="options"></param>
        /// <see cref="https://stackoverflow.com/questions/40745468/no-database-provider-has-been-configured-for-this-dbcontext"/>
        public AdventureWorksContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }


        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Person");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Address_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.StateProvinceId)
                    .HasName("IX_Address_StateProvinceID");

                entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceId, e.PostalCode })
                    .HasName("IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode")
                    .IsUnique();

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");

                entity.Property(d => d.StateProvinceId)
                 .HasColumnType("StateProvinceId");
            });

          

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact", "Person");

                entity.HasIndex(e => e.AdditionalContactInfo)
                    .HasName("PXML_Contact_AddContact");

                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_Contact_EmailAddress");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Contact_rowguid")
                    .IsUnique();

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.AdditionalContactInfo).HasColumnType("xml");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EmailPromotion).HasDefaultValueSql("0");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.MiddleName).HasColumnType("Name");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.NameStyle)
                    .HasColumnType("NameStyle")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Phone).HasColumnType("Phone");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);
            });

       
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "HumanResources");

                entity.HasIndex(e => e.LoginId)
                    .HasName("AK_Employee_LoginID")
                    .IsUnique();

                entity.HasIndex(e => e.ManagerId)
                    .HasName("IX_Employee_ManagerID");

                entity.HasIndex(e => e.NationalIdnumber)
                    .HasName("AK_Employee_NationalIDNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Employee_rowguid")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CurrentFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(256);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.NationalIdnumber)
                    .IsRequired()
                    .HasColumnName("NationalIDNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.SalariedFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SickLeaveHours).HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VacationHours).HasDefaultValueSql("0");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId);
            });

         

            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.RateChangeDate })
                    .HasName("PK_EmployeePayHistory_EmployeeID_RateChangeDate");

                entity.ToTable("EmployeePayHistory", "HumanResources");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.RateChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePayHistory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

           
            
        }
    }
}