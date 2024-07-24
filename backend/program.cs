using backend.Data;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


// Configuration is automatically set to read from appsettings.json and environment variables
var connectionString = builder.Configuration.GetConnectionString("TopSecretDBString");
// Use the connection string for something, e.g., setting up Entity Framework
builder.Services.AddDbContext<EncryptedFileContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEncryptedFileRepository, EncryptedFileRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
