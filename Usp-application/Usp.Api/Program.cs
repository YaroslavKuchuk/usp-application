using Usp.Api.BusinessLogic.Services;
using Usp.Api.BusinessLogic.Services.Abstractions;
using Usp.Api.Data.Repositories;
using Usp.Api.Data.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#warning add context here

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
