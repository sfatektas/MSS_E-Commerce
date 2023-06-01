using AspNetCoreRateLimit;
using AutoMapper;
using E_Commerce.Business.Consts;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Business.Mapper.AutoMapper;
using E_Commerce.Business.Models;
using E_Commerce.Business.Services;
using E_Commerce.Business.Services.Storage;
using E_Commerce.Business.Validations.FluentValidations;
using E_Commerce.Business.Validations.FluentValidations.CustomerValidation;
using E_Commerce.Business.Validations.FluentValidations.OrderDetailValidation;
using E_Commerce.Business.Validations.FluentValidations.OrderValidation;
using E_Commerce.Business.Validations.FluentValidations.ProductsInStockValidation;
using E_Commerce.Business.Validations.FluentValidations.ProductValidation;
using E_Commerce.Business.Validations.FluentValidations.SiteOptionValidation;
using E_Commerce.Business.Validations.FluentValidations.SliderItemsValidation;
using E_Commerce.Business.Validations.FluentValidations.SliderValidation;
using E_Commerce.Business.Validations.FluentValidations.SupplierProductValidation;
using E_Commerce.Common;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.DataAccess.UnitOfWorks;
using E_Commerce.Dtos;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Dtos.OrderDetailDtos;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Dtos.SiteOptionDtos;
using E_Commerce.Dtos.SliderDtos;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using E_Commerce.Presentation;
using E_Commerce.Presentation.ActionFilters;
using E_Commerce.Presentation.Models;
using E_Commerce.Presentation.Validators;
using E_Commerce.RabbitMQProducer.Interfaces;
using E_Commerce.RabbitMQPublisher;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                //x.UseMySQL(configuration.GetConnectionString("PleskLocalDB"));
                x.UseMySQL(configuration.GetConnectionString("SefaMySql"));
                //x.UseSqlServer(configuration.GetConnectionString("RemoteDb"));
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
                    new BrandProfile(),
                    new SizeProfile(),
                    new SliderItemProfile(),
                    new ProductProfile(),
                    new SliderProfile(),
                    new CustomerProfile(),
                    new GenderProfile(),
                    new SupplierProfile(),
                    new SupplierProductProfile(),
                    new ProductImageProfile(),
                    new ProductInStockProfile(),
                    new BasketProfile(),
                    new OtherProfile(),
                    new ProductCommentProfile(),
                    new FavoriteProductsProfile(),
                    new OrderProfile(),
                    new OrderDetailProfile(),
                    new OrderStatusTypeProfile(),
            };

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(profileList);
                opt.CreateMap<BrandCreateModel, BrandCreateDto>(); // UI mapping
                opt.CreateMap<SliderItemCreateModel, SliderItemCreateDto>();
                opt.CreateMap<ProductCreateModel, ProductCreateDto>();
                opt.CreateMap<SupplierCreateModel, SupplierCreateDto>();
                opt.CreateMap<SupplierProductCreateModel, SupplierProductCreateDto>();
                opt.CreateMap<SliderItemUpdateModel, SliderItemUpdateDto>().ReverseMap();
                opt.CreateMap<SliderUpdateModel, SliderUpdateDto>().ReverseMap();
                opt.CreateMap<SliderCreateModel, SliderCreateDto>().ReverseMap();
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUow, Uow>();
            services.AddScoped<ISiteOptionService, SiteOptionService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeTypeService, SizeTypeService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ISliderItemService, SliderItemService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISupplierService,SupplierService>();
            services.AddScoped<IAppUserService,AppUserService>();
            services.AddScoped<ISupplierProductService, SupplierProductService>();
            services.AddScoped<IProductInStockService , ProductInStockService>();
            services.AddScoped<IBasketService , BasketService>();
            services.AddScoped<ISalesProductService , SalesProductService>();
            services.AddScoped<IProductCommentService , ProductCommentService>();
            services.AddScoped<IFavoriteProductService , FavoriteProductsService>();
            services.AddScoped<IOrderService, OrderService>();
        }
        public static void ConfigureValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SiteOptionCreateDto>, SiteOptionCreateValidatior>();
            services.AddTransient<IValidator<UserLoginModel>, UserLoginModelValidator>();
            services.AddTransient<IValidator<BrandCreateModel>, BrandCreateModelValidator>();
            services.AddTransient<IValidator<SliderItemCreateModel>, SliderItemCreateModelValidator>();
            services.AddTransient<IValidator<SliderItemCreateDto>,SliderItemCreateDtoValidator>();
            services.AddTransient<IValidator<SliderCreateModel>, SliderCreateModelValidator>();
            services.AddTransient<IValidator<SliderCreateDto>, SliderCreateDtoValidator>();
            services.AddTransient<IValidator<ProductCreateModel>, ProductCreateModelValidator>();
            services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
            services.AddTransient<IValidator<SupplierCreateModel>,SupplierCreateModelValidator>();
            services.AddTransient<IValidator<SupplierCreateModel>,SupplierCreateModelValidator>();
            services.AddTransient<IValidator<SupplierProductCreateModel>, SupplierProductCreateModelValidator>();
            services.AddTransient<IValidator<SupplierProductCreateDto>, SupplierProductCreateDtoValidator>();
            services.AddTransient<IValidator<SupplierProductUpdateDto>, SupplierProductUpdateDtoValidator>();
            services.AddTransient<IValidator<ProductInStockUpdateDto>,ProductInStockUpdateDtoValidator>();
            services.AddTransient<IValidator<ProductsInStockCreateDto>,ProductInStockCreateValidator>();
            services.AddTransient<IValidator<SupplierProductUpdateModel>, SupplierProductUpdateModelValidator>();
            services.AddTransient<IValidator<CustomerCreateDto>,CustomerCreateDtoValidator>();
            services.AddTransient<IValidator<OrderCreateDto>, OrderCreateDtoValidator>();
            services.AddTransient<IValidator<OrderDetailsCreateDto>, OrderDetailCreateDtoValidator>();
            services.AddTransient<IValidator<CustomOrderCreateModel>, CustomOrderCreateModelValidator>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
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
        public static void ConfigureJWTBearer(this IServiceCollection services, IConfiguration configuration)
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
            services.AddScoped<ValidateFilterAttiribute<ProductCreateModel>>();
            services.AddScoped<ValidateFilterAttiribute<SupplierCreateModel>>();
            services.AddScoped<ValidateFilterAttiribute<SliderItemCreateModel>>();
            services.AddScoped<ValidateFilterAttiribute<SupplierProductCreateModel>>();
            services.AddScoped<ValidateFilterAttiribute<SupplierProductUpdateModel>>();
            services.AddScoped<ValidateFilterAttiribute<CustomerCreateDto>>();
            services.AddScoped<ValidateFilterAttiribute<SliderCreateModel>>();
            services.AddScoped<ValidateFilterAttiribute<Business.Models.CustomOrderCreateModel>>();
        }
        public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration.GetConnectionString("RedisConnection");
            });
            services.AddSingleton<RedisService>();
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
        public static void ConfigureRateLimit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddMemoryCache();
            var rateLimitRules = new List<RateLimitRule>()
            {
                new RateLimitRule()
                {
                    Endpoint = configuration["IpRateLimiting:Endpoint"],
                    Limit = int.Parse(configuration["IpRateLimiting:Limit"]),
                    Period = configuration["IpRateLimiting:Period"]
                }
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
                opt.QuotaExceededResponse = new()
                {
                    ContentType = "application/json",
                    Content = configuration["IpRateLimiting:ErrorMessage"],
                    StatusCode = 429
                };
                //opt.QuotaExceededMessage = new ErrorModel
                //{
                //    StatusCode = 429,
                //    Error = configuration["IpRateLimiting:ErrorMessage"].ToString()
                //}.ToString();
            });

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }
        public static void ConfigureRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton<IMailProducer, MailProducer>();
        }
    }
}
