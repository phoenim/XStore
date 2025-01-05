using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Application.Services.Users.Commands.RegisterUser;
using XStore.Application.Services.Users.Commands.RemoveUser;
using XStore.Application.Services.Users.Queries.GetRoles;
using XStore.Application.Services.Users.Queries.GetUsers;
using XStore.Application.Services.Users.Queries.LoginUser;
using XStore.Presistance.Contexts;

var builder = WebApplication.CreateBuilder(args);
var connectionStr = builder.Configuration.GetConnectionString("DefualtConnetion");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionStr));
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<ILoginUserService, LoginUserService>();

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

//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "MyAreaAdmin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");



app.Run();
