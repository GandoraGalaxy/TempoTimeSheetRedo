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

        //public TimeSheetContext(DbContextOptions options) : base(options)
        //{
        //    try
        //    {
        //        Database.Migrate();
        //    }
        //    catch (Exception)
        //    {
        //        //Should do something meaningful here                
        //    }
        //}

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

        }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<TimeClock> TimeClock { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
