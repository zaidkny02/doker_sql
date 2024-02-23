using docker_sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var server = builder.Configuration["DBServer"] ?? "localhost";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "Password1@";
var database = builder.Configuration["Database"] ?? "quanlybanhang11";

builder.Services.AddDbContext<MyDBContext>(options =>
{
   //  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
    options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID = {user};Password = {password}", 
        options => options.EnableRetryOnFailure(maxRetryCount: 2,
                    maxRetryDelay: System.TimeSpan.FromSeconds(15),
                    errorNumbersToAdd: null));
});
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
