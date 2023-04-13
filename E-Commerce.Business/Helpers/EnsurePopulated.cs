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
            if(!context.Sizes.Any())
            {
                await context.Sizes.AddRangeAsync(new List<Size>(){
                    new Size()
                    {
                        SizeTypeId = 1,
                        Value = "Small"
                    },
                    new Size()
                    {
                        SizeTypeId = 1,
                        Value = "Medium"
                    },
                    new Size()
                    {
                        SizeTypeId = 1,
                        Value = "Large"
                    },
                    new Size()
                    {
                        SizeTypeId = 1,
                        Value = "XXL"
                    },
                    new Size()
                    {
                        SizeTypeId = 1,
                        Value = "XXXL"
                    },  
                    new Size()
                    {
                        SizeTypeId = 2,
                        Value = "29 30"
                    },
                    new Size()
                    {
                        SizeTypeId = 2,
                        Value = "29 31"
                    },
                    new Size()
                    {
                        SizeTypeId = 2,
                        Value = "29 32"
                    },
                    new Size()
                    {
                        SizeTypeId = 2,
                        Value = "30 31"
                    },
                    new Size()
                    {
                        SizeTypeId = 2,
                        Value = "30 32"
                    },                   
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "36"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "37"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "38"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "39"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "40"
                    },      
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "41"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "41.5"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "42"
                    },            
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "42.5"
                    },
                    new Size()
                    {
                        SizeTypeId = 3,
                        Value = "43"
                    },

                });
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
                        InstagramLink = "aaa.pinterest.com"
                    });
            }
            if (!context.Admins.Any())
            {
                var adminList = new List<Admin>()
                {
                    new Admin
                    {
                        FirstName = "Selim",
                        UserName = "selimgunaydin",
                        Email = "selim61@gmail.com",
                        UserTypeId = (int)AppUserType.Admin,

                    },
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
                    //new Customer
                    //{
                    //    FirstName = "Sefa",
                    //    LastName = "Tektaş",
                    //    UserName = "sfatektas",
                    //    Email = "sfatektas55@gmail.com",
                    //    GenderId = (int)GenderType.Men,
                    //    UserTypeId = (int)AppUserType.Customer,

                    //},
                    new Customer
                    {
                        FirstName = "Murat",
                        LastName = "Baran",
                        UserName = "mrtbrn",
                        Email = "mrtbrn@gmail.com",
                        GenderId = (int)GenderType.Men,
                        UserTypeId = (int)AppUserType.Customer,

                    },

                };
                foreach (var customer in CustomerList)
                {
                    var result = await userManager.CreateAsync(customer, "Customer123");
                }
                await context.SaveChangesAsync();
            }
            if (!context.Suppliers.Any())
            {
                var supplierList = new List<Supplier>()
                {
                    new Supplier()
                    {
                        UserName = "ChekkoNargile",
                        Email = "info@chekko.com",
                        PhoneNumber = "05468461389",
                        CompanyName = "Chekko LTD. ŞTI",
                        CompanyUserName = "chekkonargile",
                        CompanyDetail = "Yer Fıstığı kabuklu nargile kömürü",
                        UserTypeId = (int)AppUserType.Supplier,
                    }
                };
                foreach (var supplier in supplierList)
                {
                    var result = await userManager.CreateAsync(supplier, "Supplier123");
                }
                await context.SaveChangesAsync();
            }
            //Garbage-Collector
            userManager.Dispose();
        }
    }
}
