#region Startup
var builder = WebApplication.CreateBuilder(args);

// Configure AppConfigurations
Console.WriteLine("Starting..." + builder.Environment.EnvironmentName);
builder.Configuration.AddEnvironmentVariables();
#endregion

#region Configure Services
string CORS_NAME = "gateway_service_CORSE_NAME";
var services = builder.Services;
var configuration = builder.Configuration;

services.AddCors(opt =>
{
    opt.AddPolicy(CORS_NAME, builder =>
    {
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
    });
});
services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#endregion

#region Configure
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CORS_NAME);
app.UseAuthorization();

app.MapControllers();
#endregion


app.Run();
