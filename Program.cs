using FirstAssignment.Models;
using FirstAssignment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register your services here
builder.Services.AddSingleton<UserRepos>(); // Shared instance for user data
builder.Services.AddScoped<UserService>(); // New instance for each request

builder.Services.AddAutoMapper(typeof(UserProfile)); // Registers your profile

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
