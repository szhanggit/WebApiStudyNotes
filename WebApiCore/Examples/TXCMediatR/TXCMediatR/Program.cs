#region Startup
using TXCMediatR.Extensions;
using TXCMediatR.Mapper;

var builder = WebApplication.CreateBuilder(args);
// Configure AppConfigurations
Console.WriteLine("Starting..." + builder.Environment.EnvironmentName);
builder.Configuration.AddEnvironmentVariables();

#endregion

#region Configure Services
// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpContextAccessor();
services.ConfigureMediateR();
services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion




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
