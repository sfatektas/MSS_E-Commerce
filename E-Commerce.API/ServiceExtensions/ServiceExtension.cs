using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Presentation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<E_CommerceDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("LocalDb"));
            });
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<E_CommerceDbContext>()
                .AddDefaultTokenProviders(); // TODO kullanıcıların emailine doğrulama e-postası gönderilecek
        }
        public static void ConfigureController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReferance).Assembly);
        }
    }
}
