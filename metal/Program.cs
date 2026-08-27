using metal;
using metal.Application.InterFace.Contexts;
using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.Common.Quereis.GetCategory;
using metal.Application.service.Common.Quereis.GetSlider;
using metal.Application.service.HomePages;
using metal.Application.service.Products.Facadpatern;
using metal.Application.service.Products.Quary.GetProductForSearch;
using metal.Application.service.UI.DaynamicUi.Command.AddMediaUi;
using metal.Application.service.UI.DaynamicUi.Quary.Getmedia;
using metal.Application.service.users.command;
using metal.Application.service.users.command.EditUser;
using metal.Application.service.users.command.removeuser;
using metal.Application.service.users.command.userlogin;
using metal.Application.service.users.command.UserStatusChange;
using metal.Application.service.users.quary.get;
using metal.Application.service.users.quary.getrole;
using metal.Application.Services.Users.Commands.RgegisterUser;
using metal.persistance.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string constr = @"Server=Ahmadreza\MYDB;Database=metalposters;Trusted_Connection=True;TrustServerCertificate=True;";

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddDbContext<DataBaseContext>(op => op.UseSqlServer(constr));

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<Igetuserservice, getuserService>();
builder.Services.AddScoped<igetroleservice, GetRolesService>();
builder.Services.AddScoped<IRgegisterUserService, RgegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();

builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IGetProductForSearch, GetProductForSearch>();

builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IGetMedia, GetMedia>();
builder.Services.AddScoped<IAddMediaUiService, AddMediaUiService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();
