using jwtex1.Extensions;
using jwtex1.Helpers;
using jwtex1.Services;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    var services = builder.Services;
    var configuration = builder.Configuration;
    services.AddHttpContextAccessor();//It if for initializing IHttpContextAccessor
    services.AddCors();

    services.AddAuthentication();
    services.ConfigureJWT(configuration);

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

app.UseAuthentication();//!!!
app.UseAuthorization();//!!!
// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom jwt auth middleware
//app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
