using UA.TaskManagement.Persistance;
using UA.TaskManagement.Application.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "LoginCokiee";
    opt.Cookie.HttpOnly=true;
    opt.Cookie.SameSite=SameSiteMode.Strict;
    opt.Cookie.SecurePolicy=CookieSecurePolicy.SameAsRequest;
});

builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();
var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();    
app.UseAuthorization();
app.MapControllerRoute(name: "area", pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{Controller=Account}/{Action=Login}/{id?}");
app.Run();
