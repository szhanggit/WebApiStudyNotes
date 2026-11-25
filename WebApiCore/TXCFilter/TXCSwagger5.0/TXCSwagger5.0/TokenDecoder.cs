using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace TXCSwagger5._0
{
    public interface ITokenDecoder
    {
        public string GetOid(string token);
    }
    public class TokenDecoder : ITokenDecoder
    {
        public string GetOid(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var oid = jwtSecurityToken.Claims.First(claim => claim.Type == "oid").Value;

            return oid;
        }
    }
}
