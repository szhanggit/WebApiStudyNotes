using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace jwtex1.Extensions
{
    public static class ConfigureJWTExtension
    {
		public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
		{
			//var jwtSettings = configuration.GetSection("JwtSettings");
			//var secretKey = Environment.GetEnvironmentVariable("SECRET");			
			string secretKey = configuration.GetValue<string>("AppSettings:Secret");

			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = "CodeMazeAPI", // jwtSettings["validIssuer"],
					ValidAudience = "https://localhost:5001", //jwtSettings["validAudience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
				};
			});
		}
	}
}
