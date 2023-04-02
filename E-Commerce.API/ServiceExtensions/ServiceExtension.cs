using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Mapper.AutoMapper;
using E_Commerce.Business.Services;
using E_Commerce.Business.Validations.FluentValidations.SiteOptionValidation;
using E_Commerce.Common;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.DataAccess.UnitOfWorks;
using E_Commerce.Dtos.SiteOptionDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Presentation;
using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace E_Commerce.API.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<E_CommerceDbContext>(x =>
            {
                //"RemoteDb"
                x.UseSqlServer(configuration.GetConnectionString("LocalDB"));
            });
            //services.AddIdentity<AppUser, AppRole>()
            //    .AddEntityFrameworkStores<E_CommerceDbContext>()
            //    .AddDefaultTokenProviders(); // TODO kullanıcıların emailine doğrulama e-postası gönderilecek

            services.AddIdentity<Admin, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
            })
                 .AddEntityFrameworkStores<E_CommerceDbContext>()
                 .AddDefaultTokenProviders(); // TODO kullanıcıların emailine doğrulama e-postası gönderilecek

            services.AddIdentity<Supplier, AppRole>()
                .AddEntityFrameworkStores<E_CommerceDbContext>()
                .AddDefaultTokenProviders(); // TODO kullanıcıların emailine doğrulama e-postası gönderilecek

            services.AddIdentity<Customer, AppRole>()
                .AddEntityFrameworkStores<E_CommerceDbContext>()
                .AddDefaultTokenProviders();
        }
        public static void ConfigureController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReferance).Assembly)
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var profileList = new List<Profile>
            {
                    new SiteOptionProfile(),
            };

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(profileList);
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUow, Uow>();
            services.AddScoped<ISiteOptionService, SiteOptionService>();
        }
        public static void ConfigureValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SiteOptionCreateDto>, SiteOptionCreateValidatior>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("DefaultPolicy",
                      policy =>
                      {
                                policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
            });
        }
        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}
