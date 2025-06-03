using MediatR;
using Microsoft.EntityFrameworkCore;
using moco_backend.Infrastructure.Data;
using moco_backend.Infrastructure.Security.Middleware;
using moco_backend.Infrastructure.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Configuration.AddEnvironmentVariables();
// Register the DbContext and Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<NeonDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins(
                "http://localhost:3000",        // Localhost (dev)
                "https://moco-frontend.vercel.app", // Next.js production URL
                "https://live-angular-project-123.web.app" // Angular production URL
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigins");

app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
