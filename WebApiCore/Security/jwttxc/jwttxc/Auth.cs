using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace jwttxc
{
    public interface IJwtAuth
    {
        string Authentication();
        string AuthenticationV2();
    }
    public class Auth : IJwtAuth
    {
        private readonly string _key;
        public Auth(string key)
        {
            this._key = key;
        }
        public string Authentication()
        {
            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", "10"), new Claim("UserName", "stzhang"), new Claim("Email", "steven.zhang@edenred.com") }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
        public string AuthenticationV2()
        {
            string PrivateKey = "MIIEowIBAAKCAQEAwzWRNibVvdffH1zz17ojiC+FqM5YDBicTjZ/Catrry4a/lqD5nvQHZQ4FU4stBwD966/4imlGRNcfexD2y8lLFAloBWcXk3EPOyvXjIUP95oSxODMKI7M85wjCXPoEyFBH9KtE8vLiYUpT6GZL2EB3IdbxUv8eMipSrRNBH4hBFfar3Ua9USjgXPiNzw+Uhpa5+lV2rOT6N/0TsQDEfZrfwrpoqi70dSx5vuFZbzelG5dY9TusljHm2m53aitPGk1Sbjuco4w8m0ovgZQW1t7r0jG8KJskh5BBlE4jhEedrehE+/s2kqIVirkqLv6sRxcTbpLnySAooMDRJVxHtT1QIDAQABAoIBACIVkVRGNZ3fOmssfLsXGismOQ0/cioyheA2LbpPfw7oWvg8b7lntu/jOGOn8bBFEABIN+LSaKxXMBggj7yOn8v79oXcICBrLa+BmCE3V0fLmqQ5NPfh67pg+k/OLlGL6tHdM/sFtHQ3W/V6VFb0rD/ske0aYvO2OA9kyYBw/tZ4MAMDPrNBxon2IualzEhtRjYBapMujDtWtlsSmHyiWtxpQpieH05/jWiUIToQ96oX/YjbCXMoU0P1s9NtLU+nNrMQx+Xk1ogzVTOeDTOOdKPjZf7QZDVOAVnOkfRyyZ+xq38/k6QuYrRylQnFry/wXmLEg51Z7+0F3ZWSc6VORMUCgYEA4Avb35BduJmTMSfHNgD6ZO0u4tqhnJQ6ITULT/+WL/WIBJYe0BLOqnKRGCKMkET86DohTZWZXlAiU4DsXeeN48Fw9ZMEvmZhXqqEj3F5Cpbg0OIGCZPjHV3t6gcMEShmMGgkah7N8l2MZ5dVQsq6Lz3v74PLETFg0uKfocTrGx8CgYEA3wzW9Lv0xaLSCYt2tqWsY8TaS/LRCZmFByQvfdiu5nFUyYfTVuhmC9x4CWCuIedfm9tJGpD6zyyi+62SA+fX/W4Dwy693LAYumYACXltqTPXW3XXMIEj3HhJYhTxOhYHosqwj4GibJDflXlaI2QD8UdTF5pqsLz8gs3Ij6CTJosCgYBUq0ahm04/2BHvLqgzOXVnNNdWNeeDY+T/7arjxaQ9ZZ3Mler5GVJuybMZmtziHKAzJty1FEcMhF4kjoFFD5/opY8Jz1Con8pGW0yTZP+oR9KYPgKoFfJrg7bIjXc6+Lh9rK2uSQvtfvrznxZCkpiAB/kn2/ee/LkpmSlYmjF7YwKBgQCMgAf/TU4YGEH55TG4R4/ZoKxpXuCyDVQwdWi8+vrhCc6Ay+AiRG3TVuL99Tp6/MXK5UydQWnbiqB3rJPnhekWKHCSSCUsmHhbIdkwHp8nEBK99/K/CPnP7K087TgugKX6s3aYTu5DONa9zx0qYdvh5i2/FnPSNJlSw9FsN5e5lQKBgEbv5GqdE9djhQ+7KS7st3kSgGPRRql7g1GknYpqjYTrwBTTagUCqJNtCSFy5PN5xKbYpuyEReTin7ApO2iYkK+my0XR+/TS//tw7DvRvX5MdKHUhAPrLJl3RrUcd4s6eO2BZpb8oLRamqpJ0fs1qWGSTprBR3Prtg8hj75woNMx";
            RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey( // Convert the loaded key from base64 to bytes.
            source: Convert.FromBase64String(PrivateKey), // Token is signed with private key
            bytesRead: out int _); // Discard the out variable

            var signingCredentials = new SigningCredentials(
            key: new RsaSecurityKey(rsa),
            algorithm: SecurityAlgorithms.RsaSha256 // Important to use RSA version of the SHA algo
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>()
            {
                new Claim("userId", "8"),
                new Claim("userName", "stzhang"),
            };

            //4. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "https://api-dev.txc.edenred.net/",
                Audience = "TXC",
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = signingCredentials
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);


            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
