using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace jwttxc.Extensions
{
    public static class JwtAuthExtension
    {
        public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var superAdminKey = "hWmYq3t6w9z$C&F)J@NcRfUjXn2r4u7x";
            var gatewayKey = "hWmYq3t6w9z$C&F)J@NcRfUjXn2r4u7x";
            var asymmetricPublicKey = "MIIBCgKCAQEAwzWRNibVvdffH1zz17ojiC+FqM5YDBicTjZ/Catrry4a/lqD5nvQHZQ4FU4stBwD966/4imlGRNcfexD2y8lLFAloBWcXk3EPOyvXjIUP95oSxODMKI7M85wjCXPoEyFBH9KtE8vLiYUpT6GZL2EB3IdbxUv8eMipSrRNBH4hBFfar3Ua9USjgXPiNzw+Uhpa5+lV2rOT6N/0TsQDEfZrfwrpoqi70dSx5vuFZbzelG5dY9TusljHm2m53aitPGk1Sbjuco4w8m0ovgZQW1t7r0jG8KJskh5BBlE4jhEedrehE+/s2kqIVirkqLv6sRxcTbpLnySAooMDRJVxHtT1QIDAQAB"; // Token is verified with public key
            var asymmetricPrivateKey = "MIIEowIBAAKCAQEAwzWRNibVvdffH1zz17ojiC+FqM5YDBicTjZ/Catrry4a/lqD5nvQHZQ4FU4stBwD966/4imlGRNcfexD2y8lLFAloBWcXk3EPOyvXjIUP95oSxODMKI7M85wjCXPoEyFBH9KtE8vLiYUpT6GZL2EB3IdbxUv8eMipSrRNBH4hBFfar3Ua9USjgXPiNzw+Uhpa5+lV2rOT6N/0TsQDEfZrfwrpoqi70dSx5vuFZbzelG5dY9TusljHm2m53aitPGk1Sbjuco4w8m0ovgZQW1t7r0jG8KJskh5BBlE4jhEedrehE+/s2kqIVirkqLv6sRxcTbpLnySAooMDRJVxHtT1QIDAQABAoIBACIVkVRGNZ3fOmssfLsXGismOQ0/cioyheA2LbpPfw7oWvg8b7lntu/jOGOn8bBFEABIN+LSaKxXMBggj7yOn8v79oXcICBrLa+BmCE3V0fLmqQ5NPfh67pg+k/OLlGL6tHdM/sFtHQ3W/V6VFb0rD/ske0aYvO2OA9kyYBw/tZ4MAMDPrNBxon2IualzEhtRjYBapMujDtWtlsSmHyiWtxpQpieH05/jWiUIToQ96oX/YjbCXMoU0P1s9NtLU+nNrMQx+Xk1ogzVTOeDTOOdKPjZf7QZDVOAVnOkfRyyZ+xq38/k6QuYrRylQnFry/wXmLEg51Z7+0F3ZWSc6VORMUCgYEA4Avb35BduJmTMSfHNgD6ZO0u4tqhnJQ6ITULT/+WL/WIBJYe0BLOqnKRGCKMkET86DohTZWZXlAiU4DsXeeN48Fw9ZMEvmZhXqqEj3F5Cpbg0OIGCZPjHV3t6gcMEShmMGgkah7N8l2MZ5dVQsq6Lz3v74PLETFg0uKfocTrGx8CgYEA3wzW9Lv0xaLSCYt2tqWsY8TaS/LRCZmFByQvfdiu5nFUyYfTVuhmC9x4CWCuIedfm9tJGpD6zyyi+62SA+fX/W4Dwy693LAYumYACXltqTPXW3XXMIEj3HhJYhTxOhYHosqwj4GibJDflXlaI2QD8UdTF5pqsLz8gs3Ij6CTJosCgYBUq0ahm04/2BHvLqgzOXVnNNdWNeeDY+T/7arjxaQ9ZZ3Mler5GVJuybMZmtziHKAzJty1FEcMhF4kjoFFD5/opY8Jz1Con8pGW0yTZP+oR9KYPgKoFfJrg7bIjXc6+Lh9rK2uSQvtfvrznxZCkpiAB/kn2/ee/LkpmSlYmjF7YwKBgQCMgAf/TU4YGEH55TG4R4/ZoKxpXuCyDVQwdWi8+vrhCc6Ay+AiRG3TVuL99Tp6/MXK5UydQWnbiqB3rJPnhekWKHCSSCUsmHhbIdkwHp8nEBK99/K/CPnP7K087TgugKX6s3aYTu5DONa9zx0qYdvh5i2/FnPSNJlSw9FsN5e5lQKBgEbv5GqdE9djhQ+7KS7st3kSgGPRRql7g1GknYpqjYTrwBTTagUCqJNtCSFy5PN5xKbYpuyEReTin7ApO2iYkK+my0XR+/TS//tw7DvRvX5MdKHUhAPrLJl3RrUcd4s6eO2BZpb8oLRamqpJ0fs1qWGSTprBR3Prtg8hj75woNMx";

            services.AddSingleton<RsaSecurityKey>(provider =>
            {
                RSA rsa = RSA.Create();
                var publicKey = Convert.FromBase64String(asymmetricPublicKey);
                rsa.ImportRSAPublicKey(
                source: publicKey, // Token is verified with public key
                bytesRead: out int _
                );
                return new RsaSecurityKey(rsa);
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                SecurityKey rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>(); // Token is verified with public key

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    //ValidIssuer = "http://localhost:8007",
                    ValidateIssuer = false,
                    ValidAudience = "TXC",
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = rsa
                };
                x.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        if (context.Response == null || context.Response.StatusCode != 401)
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            var response = Response.Fail<string>("Unauthorized", null);
                            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                        }
                    }

                };
            }).AddJwtBearer("CreateSuperAdmin", x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(superAdminKey))
                };
                x.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        if (context.Response == null || context.Response.StatusCode != 401)
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            var response = Response.Fail<string>("Unauthorized", null);
                            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                        }
                    }
                };
            });


            services.AddSingleton<IJwtAuth>(new Auth(gatewayKey));
            return services;
        }
    }
}
