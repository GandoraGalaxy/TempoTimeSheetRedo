using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models.Entities;

namespace TimeSheetAppRemodel.EF
{
    public class TimeSheetContext : DbContext
    {
        public TimeSheetContext()
        {

        }

        public TimeSheetContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=TimeSheetRemodel;Trusted_Connection=True;MultipleActiveResultSets=true;",
                    options => options.ExecutionStrategy(c => new ConnectionStrategy(c)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id).HasName("Users").IsUnique();
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasIndex(e => e.ID).HasName("Users").IsUnique();
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.HasIndex(e => e.ID).HasName("Users").IsUnique();

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<TimeClock>(entity =>
            {
                entity.HasIndex(e => e.ID).HasName("Users").IsUnique();

                entity.Property(e => e.ClockIn).HasColumnType("datetime").HasDefaultValueSql("getdate()");

                entity.Property(e => e.ClockOut).HasColumnType("datetime").HasDefaultValueSql("getdate()");

                entity.Property(e => e.InLunch).HasColumnType("datetime").HasDefaultValueSql("getdate()");

                entity.Property(e => e.OutLunch).HasColumnType("datetime").HasDefaultValueSql("getdate()");

                entity.Property(e => e.TotalHours).HasColumnType("datetime").HasDefaultValueSql("getdate()")
                    .HasComputedColumnSql("([ClockIn]+[ClockOut])-([InLunch]+[OutLunch])");
            });
        }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<TimeClock> TimeClock { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
