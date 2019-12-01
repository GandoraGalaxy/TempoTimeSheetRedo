using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheet.MVC.Models;

namespace TimeSheet.MVC.Models
{
    public class TimeSheetMVCContext : DbContext
    {
        public TimeSheetMVCContext (DbContextOptions<TimeSheetMVCContext> options)
            : base(options)
        {
        }

        public DbSet<TimeSheet.MVC.Models.TimeClock> TimeClock { get; set; }

        public DbSet<TimeSheet.MVC.Models.Payroll> Payroll { get; set; }

        public DbSet<TimeSheet.MVC.Models.Division> Division { get; set; }

        public DbSet<TimeSheet.MVC.Models.Role> Role { get; set; }
    }
}
