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
            var sql = $"Delete from Store.{tableName}";
            context.Database.ExecuteSqlCommand(sql);
        }
        public static void ResetIdentity(TimeSheetContext context)
        {
            var tables = new[] {"Categories","Customers",
                "OrderDetails","Orders","Products","ShoppingCartRecords"};
            foreach (var itm in tables)
            {
                var sql = $"DBCC CHECKIDENT (\"Store.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(sql);
            }
        }

        public static void SeedData(TimeSheetContext context)
        {
            try
            {
                //if (!context.Div.Any())
                //{
                //    context.Divisions.AddRange(StoreSampleData.GetCategories());
                //    context.SaveChanges();
                //}
                //if (!context.Products.Any())
                //{
                //    context.Products.AddRange(
                //        StoreSampleData.GetProducts(context.Categories.ToList()));
                //    context.SaveChanges();
                //}
                //if (!context.Customers.Any())
                //{
                //    context.Customers.AddRange(
                //        StoreSampleData.GetAllCustomerRecords(context));
                //    context.SaveChanges();
                //}
                //var customer = context.Customers.FirstOrDefault();
                //if (!context.Orders.Any())
                //{
                //    context.Orders.AddRange(StoreSampleData.GetOrders(customer, context));
                //    context.SaveChanges();
                //}
                //if (!context.ShoppingCartRecords.Any())
                //{
                //    context.ShoppingCartRecords.AddRange(
                //        StoreSampleData.GetCart(customer, context));
                //    context.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
