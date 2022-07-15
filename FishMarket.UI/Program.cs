using Microsoft.EntityFrameworkCore;
using FishMarket.UI.Data;
using Serilog;
using FishMarket.Infrastructure;
using FishMarket.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

