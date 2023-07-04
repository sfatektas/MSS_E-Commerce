using AspNetCoreRateLimit;
using E_Commerce.API.ServiceExtensions;
using E_Commerce.Business.BackgroundServices;
using E_Commerce.Business.Helpers;
using E_Commerce.Business.Hubs;
using E_Commerce.Presentation.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.ConfigureController();
builder.Services.Configure<ForwardedHeadersOptions>(options => // Kullan�c� ip bilgisini almak i�in gerekli configuraiton
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureValidations();
builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    option => 
    {
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    }
);
builder.Services.ConfigureLogger();
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureJWTBearer(builder.Configuration);
builder.Services.ConfigureRedis(builder.Configuration);
builder.Services.ConfigureStorage();
builder.Services.ConfigureRateLimit(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureRabbitMQ();
builder.Services.AddHostedService<ForStandByBackgroundService>();



var app = builder.Build();

var host = new WebHostBuilder();
host.CaptureStartupErrors(true)
    .UseSetting("detailedErrors", "true");

// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseMiddleware<RequestResponseMiddleware>(); 
app.UseMiddleware<TokenMiddleware>();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseForwardedHeaders();
app.UseStaticFiles();

//app.UseSession(); //
app.UseIpRateLimiting();

//app.UseRouting();

//app.UseMiddleware<CustomRoutingMiddleware>()

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<VisitHub>("/visit");

app.MapControllers();

// await app.SeedData(); //Seed Data added.

app.Run();
//mrt feature added
