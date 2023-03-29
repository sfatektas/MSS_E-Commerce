using E_Commerce.Presentation;

namespace E_Commerce.API.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReferance).Assembly);
        }
    }
}
