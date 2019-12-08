using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using TimeSheetAppRemodel.EF;

namespace TimeSheetAppRemodel.Initializers
{
    public class TimeSheetDataInitializer
    {
        public static void InitializeData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<TimeSheetContext>();
            InitializeData(context);
        }
        public static void InitializeData(TimeSheetContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
        public static void ClearData(TimeSheetContext context)
        {
            ExecuteDeleteSQL(context, "TimeClock");
            ExecuteDeleteSQL(context, "Users");
            ResetIdentity(context);
        }
        public static void ExecuteDeleteSQL(TimeSheetContext context, string tableName)
        {
            var sql = $"Delete from TimeSheet.{tableName}";
            context.Database.ExecuteSqlCommand(sql);
        }
        public static void ResetIdentity(TimeSheetContext context)
        {
            var tables = new[] {"Divisions","Users","Payroll","Roles","TimeClock"};
            foreach (var itm in tables)
            {
                var sql = $"DBCC CHECKIDENT (\"TimeSheet.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(sql);
            }
        }

        public static void SeedData(TimeSheetContext context)
        {
            try
            {
                if (!context.Divisions.Any())
                {
                    context.Divisions.AddRange(TimeSheetSampleData.GetDivisions());
                    context.SaveChanges();
                }
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(TimeSheetSampleData.GetRoles());
                    context.SaveChanges();
                }
                if (!context.TimeClock.Any())
                {
                    context.TimeClock.AddRange(TimeSheetSampleData.GetTime());
                    context.SaveChanges();
                }
                if (!context.Payroll.Any())
                {
                    context.Payroll.AddRange(TimeSheetSampleData.GetPayroll());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
