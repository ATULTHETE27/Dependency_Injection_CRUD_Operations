using Asp.netCoreMVCIntro.Context;
using Asp.netCoreMVCIntro.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register DbContext
var connectionString = builder.Configuration.GetConnectionString("CollageDbConnection");
builder.Services.AddDbContext<CollageDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICollageService, CollageService>();
//Register Article service
builder.Services.AddScoped<IStudentService, StudentService>();

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

app.MapControllerRoute(
    name: "addtutorial",
    pattern: "/newtutorial",
    defaults: new { controller = "Tutorial", action = "CreateTutorial" });


app.Run();
