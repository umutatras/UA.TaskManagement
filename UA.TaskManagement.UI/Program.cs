using UA.TaskManagement.Persistance;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistanceServices(builder.Configuration);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
