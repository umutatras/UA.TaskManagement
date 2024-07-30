using UA.TaskManagement.Persistance;
using UA.TaskManagement.Application.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();
var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();
app.Run();
