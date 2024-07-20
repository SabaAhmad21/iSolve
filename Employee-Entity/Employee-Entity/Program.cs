using Employee_Entity.DBModels;
using Employee_Entity.Infrastructure.Implementation;
using Employee_Entity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
                                                           

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeManagementContext>(x => x.UseSqlServer("Server=DESKTOP-MPQVSOQ;Database=EmployeeManagement;Trusted_Connection=True;TrustServerCertificate=yes;"));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IGenderRepository, GenderRepository>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
