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
        public List<string> GetRoleFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var roles = jsonToken?.Claims
                                 .Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                                 .Select(c => c.Value)
                                 .ToList();
            return roles ?? new List<string>(); // Return roles or an empty list if none found
        }

    }
}