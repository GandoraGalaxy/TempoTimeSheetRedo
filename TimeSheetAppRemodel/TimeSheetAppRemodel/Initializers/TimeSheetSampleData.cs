using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeSheetAppRemodel.EF;
using TimeSheet.Models.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TimeSheetAppRemodel.Initializers
{
    public class TimeSheetSampleData
    {
        public static IEnumerable<Division> GetDivisions() => new List<Division>
        {
            new Division {Name = "Floor Walker"},
            new Division {Name = "Retail"},
            new Division {Name = "Pets"},
            new Division {Name = "Cashier"},
            new Division {Name = "Home Goods"}
        };

        public static async Task Initialize(TimeSheetContext context,
                             UserManager<User> userManager,
                             RoleManager<Role> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";
            string normName1 = role1.ToUpper();

            string role2 = "HR";
            string desc2 = "This is the HR role";
            string normName2 = role2.ToUpper();

            string role3 = "Manager";
            string desc3 = "This is the Manager role";
            string normName3 = role3.ToUpper();

            string role4 = "Employee";
            string desc4 = "This is a basic Employee role";
            string normName4 = role4.ToUpper();


            string password = "Develop@90";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new Role(role1, desc1, normName1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new Role(role2, desc2, normName2, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new Role(role3, desc3, normName3, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role4) == null)
            {
                await roleManager.CreateAsync(new Role(role4, desc4, normName4, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("bill@develop.com") == null)
            {
                var user = new User
                {
                    UserName = "bill@develop.com",
                    Email = "bill@develop.com",
                    FirstName = "Bill",
                    LastName = "Tech"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
            }
            if (await userManager.FindByNameAsync("ricky@develop.com") == null)
            {
                var user = new User
                {
                    UserName = "ricky@develop.com",
                    Email = "ricky@develop.com",
                    FirstName = "Ricky",
                    LastName = "Doe"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
            if (await userManager.FindByNameAsync("jimmy@develop.com") == null)
            {
                var user = new User
                {
                    UserName = "jimmy@develop.com",
                    Email = "jimmy@develop.com",
                    FirstName = "Jimmy",
                    LastName = "Roberts"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
            }
            if (await userManager.FindByNameAsync("billy@develop.com") == null)
            {
                var user = new User
                {
                    UserName = "billy@develop.com",
                    Email = "billy@develop.com",
                    FirstName = "Billy",
                    LastName = "Smith"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role4);
                }
            }
        }
    }
}
