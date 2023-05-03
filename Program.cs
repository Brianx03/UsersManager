using Microsoft.OpenApi.Models;
using UsersManager.Interfaces;
using UsersManager.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Manager API", Description = "Manages Users Info", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserManager API V1");
});

app.MapGet("/User/{userId}", (int userId, IUsersService usersService) => usersService.GetUserDataAsync(userId));
app.MapGet("/AllUsers", (IUsersService usersService) => usersService.GetAllUsersDataAsync());

app.Run();
