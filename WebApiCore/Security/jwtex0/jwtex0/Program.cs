using jwtex0.Extensions;
using jwtex0.Helpers;
using jwtex0.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    var services = builder.Services;
    var configuration = builder.Configuration;
    services.AddHttpContextAccessor();//It if for initializing IHttpContextAccessor
    services.AddCors();
    services.AddControllers();
    services.AddSwagger(configuration);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
