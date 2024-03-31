using Microsoft.EntityFrameworkCore;
using tz;
using tz.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Server = LAPTOP-FU2ARVTC\\SQLEXPRESS02;User= oleg; Password = 123; Database = WeatherDatabase; TrustServerCertificate=True; ");


builder.Services.AddDbContext<WeatherDbContext>(options =>
   options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "weatherArchive",
        pattern: "Home/WeatherArchive/{year}/{month}",
        defaults: new { controller = "Home", action = "WeatherArchive" });
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
