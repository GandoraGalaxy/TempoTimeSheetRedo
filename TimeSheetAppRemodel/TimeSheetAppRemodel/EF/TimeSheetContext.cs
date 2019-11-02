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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=TimeSheetRemodel;Trusted_Connection=True;MultipleActiveResultSets=true;",
                    options => options.ExecutionStrategy(c => new ConnectionStrategy(c)));
            }
        }
    }
}
