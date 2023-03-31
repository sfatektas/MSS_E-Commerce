using E_Commerce.API.ServiceExtensions;
using E_Commerce.Business.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureController();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();
await app.SeedData();

app.Run();
//mrt feature added
