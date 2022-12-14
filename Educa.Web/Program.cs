using AutoMapper;
using Educa.DependencyInjection;
using Educa.Infrastructure.AutoMapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

DependencyRegistration.RegistrarDependencias(builder.Services, builder.Configuration);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors(builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials()
             .WithOrigins(
                 "http://localhost:44426"
              )
             .SetPreflightMaxAge(TimeSpan.FromDays(7)));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;


app.Run();
