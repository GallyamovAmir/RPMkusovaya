using Microsoft.EntityFrameworkCore;
using RPM.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


string conn = "Data Source=MSI;Initial Catalog=RpmAmir;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

builder.Services.AddDbContext<RpmAmirContext>(options =>
                options.UseSqlServer(conn));

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
