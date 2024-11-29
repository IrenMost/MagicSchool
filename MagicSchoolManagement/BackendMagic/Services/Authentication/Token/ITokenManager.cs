using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Services.Authentication.Token
{
    public interface ITokenManager
    {
        public string GenerateToken(IdentityUser user, IList<string> roles);
    }
}
