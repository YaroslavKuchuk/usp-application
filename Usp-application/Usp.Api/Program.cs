using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Usp.Api.BusinessLogic.Services;
using Usp.Api.BusinessLogic.Services.Abstractions;
using Usp.Api.Data.Models;
using Usp.Api.Data.Repositories;
using Usp.Api.Data.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#warning add context here

var conn = new SqlConnection("Server=tcp:ja-main.database.windows.net,1433;Initial Catalog=usp;Persist Security Info=False;User ID=ja-admin;Password=V@rious1202;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

builder.Services.AddDbContext<UspContext>();

builder.Services.AddTransient(typeof(ISellingPointRepository), typeof(SellingPointRepository));
builder.Services.AddTransient(typeof(ISellingPointService), typeof(SellingPointService));

builder.Services.AddControllers();
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
