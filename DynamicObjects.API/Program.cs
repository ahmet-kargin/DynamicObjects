using DynamicObjects.Application.UseCases;
using DynamicObjects.Domain.Repositories;
using DynamicObjects.Domain.Services;
using DynamicObjects.Infrastructure.Persistence;
using DynamicObjects.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CreateDynamicObjectUseCase ve DynamicObjectService'i DI container'a ekliyoruz
builder.Services.AddScoped<CreateDynamicObjectUseCase>();
builder.Services.AddScoped<ReadDynamicObjectUseCase>();
builder.Services.AddScoped<DeleteDynamicObjectUseCase>();
builder.Services.AddScoped<UpdateDynamicObjectUseCase>();

builder.Services.AddScoped<DynamicObjectService>();
builder.Services.AddScoped<IDynamicObjectRepository, DynamicObjectRepository>();

var connectionString = builder.Configuration.GetConnectionString("DynamicDbContext");
builder.Services.AddDbContext<DynamicDbContext>(options =>
	options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
