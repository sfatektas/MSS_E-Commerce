using AutoMapper;
using E_Commerce.Business.Consts;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Business.Mapper.AutoMapper;
using E_Commerce.Business.Services;
using E_Commerce.Business.Services.Storage;
using E_Commerce.Business.Validations.FluentValidations;
using E_Commerce.Business.Validations.FluentValidations.SiteOptionValidation;
using E_Commerce.Common;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.DataAccess.UnitOfWorks;
using E_Commerce.Dtos;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.SiteOptionDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Presentation;
using E_Commerce.Presentation.ActionFilters;
using E_Commerce.Presentation.Models;
using E_Commerce.Presentation.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

namespace E_Commerce.API.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<E_CommerceDbContext>(x =>
            {
                //"RemoteDb"
                x.UseSqlServer(configuration.GetConnectionString("RemoteDb"));
            });
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = IdentityDbOptions.RequiredLength;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = IdentityDbOptions.MaxFailedAccessAttempts;

                //Sıgin Options
                opt.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<E_CommerceDbContext>()
                .AddDefaultTokenProviders(); // TODO kullanıcıların emailine doğrulama e-postası gönderilecek
            // !!!!!!!!NOT: BİRDEN FAZA IDENTITY SCHEMA KULLANIMI AZURE TARAFINDA 500.30 HATASI DÖNDÜRÜYOR.
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
                    new CategoryProfile(),
                    new ColorProfile(),
                    new SizeTypeProfile(),
                    new BrandProfile<BrandCreateModel>()
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
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenManager,TokenManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeTypeService, SizeTypeService>();
            services.AddScoped<IBrandService, BrandService>();
        }
        public static void ConfigureValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SiteOptionCreateDto>, SiteOptionCreateValidatior>();
            services.AddTransient<IValidator<UserLoginModel>, UserLoginModelValidator>();
            services.AddTransient<IValidator<BrandCreateModel>, BrandCreateModelValidator>();
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
        public static void ConfigureJWTBearer(this IServiceCollection services , IConfiguration configuration)
        {
            var jwtoptions = configuration.GetSection("JWTTokenOptions");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.Audience = jwtoptions["Audience"];
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions["SecretKey"])),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false, //üreteni doğrulama
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero, // sunucu taraflı saniye gecikmesi durumu ??
                };
            });
        }
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidateFilterAttiribute<UserLoginModel>>();
            services.AddScoped<ValidateFilterAttiribute<BrandCreateModel>>();
        } 
        public static void ConfigureRedis(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration.GetConnectionString("RedisConnection");
            });
            services.AddScoped<RedisService>();
        }
        public static void ConfigureSessions(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("JWTTokenOptions");
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(int.Parse(jwtOptions["ExpireMinitue"]));
            });
        }
        public static void ConfigureStorage(this IServiceCollection services)
        {
            //services.AddScoped<IStorage , AzureStorage>();
            services.AddScoped<IStorage, LocalStorage>();
        }

    }
}
