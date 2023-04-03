using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Helpers
{
    public static class EnsurePopulated
    {
        public async static Task SeedData(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<E_CommerceDbContext>();


            UserManager<AppUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            //UserManager<Admin> _adminService = scope.ServiceProvider.GetRequiredService<UserManager<Admin>>();
            //UserManager<Customer> _customerManager = scope.ServiceProvider.GetRequiredService<UserManager<Customer>>();

            var migrations = await context.Database.GetPendingMigrationsAsync();
            if (migrations.Any())
            {
                context.Database.Migrate();
            }
            if (!context.UserTypes.Any())
            {
                await context.AddRangeAsync(new List<UserType>
                {
                    new UserType
                    {
                        IsActive= true,
                        Defination = "Admin"
                    },
                    new UserType
                    {
                        IsActive= true,
                        Defination = "Customer"
                    },
                    new UserType
                    {
                        IsActive= true,
                        Defination = "Supplier"
                    },
                });
            }
            if (!context.Genders.Any())
            {
                await context.AddRangeAsync(new List<Gender>
                {
                    new Gender
                    {
                        IsActive= true,
                        Defination = "Erkek"
                    },
                    new Gender
                    {
                        IsActive= true,
                        Defination = "Kadın"
                    },
                    new Gender
                    {
                        IsActive= true,
                        Defination = "Belirsiz"
                    },
                });
                await context.SaveChangesAsync();

            }
            if (!context.SiteOptions.Any())
            {
                await context.SiteOptions.AddAsync(
                    new SiteOption()
                    {
                        Logo = "MssE-Ticaret",
                        Slogan ="Eller Eller Havaya",
                        FacebookLink = "facebook/selimgunaydin",
                        Adress = "Selim's Home",
                        Email = "frontçuSelim31@gmail.com",
                        LinkedInLink = "frontçuSelimlinkedin.in",
                        PhoneNumber = "054984357954",
                        TwitterLink = "xxx.twiter.com",
                        PinterestLink = "aaa.pinterest.com"
                    });
            }
            if (context.Admins.Any())
            {
                var adminList = new List<Admin>()
                {
                    new Admin
                    {
                        FirstName = "Selim2",
                        UserName = "selimgunaydin2",
                        Email = "selim61_2@gmail.com",
                        UserTypeId = (int)AppUserType.Admin,

                    }
                };
                foreach (var admin in adminList)
                {
                    var result = await userManager.CreateAsync(admin, "Admin123");
                }
            }
            if (!context.Customers.Any())
            {
                var CustomerList = new List<Customer>()
                {
                    new Customer
                    {
                        FirstName = "Sefa",
                        LastName = "Tektaş",
                        UserName = "sfatektas",
                        Email = "sfatektas55@gmail.com",
                        GenderId = (int)GenderType.Men,
                        UserTypeId = (int)AppUserType.Customer,

                    }
                };
                foreach (var customer in CustomerList)
                {
                    var result = await userManager.CreateAsync(customer, "Customer123");
                }
                await context.SaveChangesAsync();
            }
            //Garbage-Collector
            userManager.Dispose();
        }
    }
}
