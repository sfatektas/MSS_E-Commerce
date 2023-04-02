using E_Commerce.API.ServiceExtensions;
using E_Commerce.Business.Helpers;
using E_Commerce.Presentation.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using NLog;

var builder = WebApplication.CreateBuilder(args);

//LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
// Add services to the container.
builder.Services.ConfigureController();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureLogger();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();


app.UseCors();
app.UseAuthorization();

app.MapControllers();

//await app.SeedData(); //Seed Data added.

app.Run();
//mrt feature added
