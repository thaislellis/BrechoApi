using BrechoApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

connectionString = connectionString.Replace(
    "${DB_PASSWORD}",
    Environment.GetEnvironmentVariable("DB_PASSWORD")
);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));