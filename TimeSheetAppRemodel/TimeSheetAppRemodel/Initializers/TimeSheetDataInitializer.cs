using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeSheetAppRemodel.EF;

namespace TimeSheetAppRemodel.Initializers
{
    public class TimeSheetDataInitializer
    {
        //public static void InitializeData(IServiceProvider serviceProvider)
        //{
        //    var context = serviceProvider.GetService<TimeSheetContext>();
        //    InitializeData(context);
        //}

        //public static void InitializeData(TimeSheetContext context)
        //{
        //    context.Database.Migrate();
        //    ClearData(context);
        //    SeedData(context);
        //}

        //public static void ClearData(TimeSheetContext context)
        //{
        //    ExecuteDeleteSQL(context, "Categories");
        //    ExecuteDeleteSQL(context, "Customers");
        //    ResetIdentity(context);
        //}
    }
}
