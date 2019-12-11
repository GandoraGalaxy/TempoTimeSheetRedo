﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheetAppRemodel.EF;

namespace TimeSheetAppRemodel.Migrations
{
    [DbContext(typeof(TimeSheetContext))]
    [Migration("20191210042010_DBContext")]
    partial class DBContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeSheet.Models.Entities.Division", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("User");

                    b.HasKey("ID");

                    b.HasIndex("ID")
                        .IsUnique()
                        .HasName("Divisions");

                    b.HasIndex("User")
                        .IsUnique()
                        .HasFilter("[User] IS NOT NULL");

                    b.ToTable("Divisions","TimeSheet");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.Payroll", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeIDId");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ID");

                    b.HasIndex("EmployeeIDId");

                    b.HasIndex("ID")
                        .IsUnique()
                        .HasName("Payroll");

                    b.ToTable("Payroll","TimeSheet");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles","TimeSheet");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.TimeClock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClockIn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("ClockOut")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("EmployeeIDId");

                    b.Property<DateTime>("InLunch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("OutLunch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("TotalHours")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasComputedColumnSql("([ClockIn]+[ClockOut])-([InLunch]+[OutLunch])");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeIDId");

                    b.HasIndex("ID")
                        .IsUnique()
                        .HasName("Users");

                    b.ToTable("TimeClock","TimeSheet");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("Users");

                    b.ToTable("Users","TimeSheet");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.Division", b =>
                {
                    b.HasOne("TimeSheet.Models.Entities.User", "ManagerID")
                        .WithOne("DivisionID")
                        .HasForeignKey("TimeSheet.Models.Entities.Division", "User");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.Payroll", b =>
                {
                    b.HasOne("TimeSheet.Models.Entities.User", "EmployeeID")
                        .WithMany()
                        .HasForeignKey("EmployeeIDId");
                });

            modelBuilder.Entity("TimeSheet.Models.Entities.TimeClock", b =>
                {
                    b.HasOne("TimeSheet.Models.Entities.User", "EmployeeID")
                        .WithMany()
                        .HasForeignKey("EmployeeIDId");
                });
#pragma warning restore 612, 618
        }
    }
}
