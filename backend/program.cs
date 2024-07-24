using backend.Data;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuration is automatically set to read from appsettings.json and environment variables
var connectionString = builder.Configuration.GetConnectionString("TopSecretDBString");
// Use the connection string for something, e.g., setting up Entity Framework
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
