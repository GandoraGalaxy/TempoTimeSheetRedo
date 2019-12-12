using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheet.MVC.Models;
using TimeSheet.Models.Entities;

namespace TimeSheet.MVC.Models
{
    public class TimeSheetMVCContext : DbContext
    {
        public TimeSheetMVCContext (DbContextOptions<TimeSheetMVCContext> options)
            : base(options)
        {
        }

        public DbSet<TimeClock> TimeClock { get; set; }

        public DbSet<Payroll> Payroll { get; set; }

        public DbSet<Division> Division { get; set; }

        public DbSet<Role> Role { get; set; }
    }
}
