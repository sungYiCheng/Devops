using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using practice.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BbtestContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("BbtestDatabase")));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
