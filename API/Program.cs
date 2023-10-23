using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

app.UseAuthentication();  // do you have a valid token?
app.UseAuthorization();   // what are you allowed to do with this valid token

app.MapControllers();

app.Run();
