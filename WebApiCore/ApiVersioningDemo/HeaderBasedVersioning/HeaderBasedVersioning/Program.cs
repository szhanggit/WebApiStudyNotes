using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//configure API versionining
builder.Services.AddApiVersioning(x =>
{
    //Specifies defaulr version of APIs. ApiVersion type is a part of Microsoft.AspNetCore.Versioning NuGet.
    x.DefaultApiVersion = new ApiVersion(1, 0);
    //if client does not specify version in API, use default API. If this is false and version is not specified by client, API throws UnsupportedApiVersionException.
    x.AssumeDefaultVersionWhenUnspecified = true;
    //return the API version in response header
    x.ReportApiVersions = true;
    //declare header parameter for Header based versioning. Otherwise comment it
    x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
