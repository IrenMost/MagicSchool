using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.IdentityModel.Tokens.Jwt;

namespace BackendMagic.Services.Authentication.Token
{
    public class TokenExtractor
    {
        public string GetEmailFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var result = jsonToken?.Claims.First(c => c.Type == "email").Value;
            return result;

        }

        public string GetUsernameFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var result = jsonToken?.Claims.First(c => c.Type == "sub").Value;
            return result;
        }
    }
    
}
