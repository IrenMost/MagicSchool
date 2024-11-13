using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;

namespace BackendMagic.Services.Authentication
{
    public class RoleManagementService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        
        public RoleManagementService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task EnsureRolesAndClaimsAsync()
        {
            string[] roles = { "HouseElf", "Student", "Teacher", "Headmaster", "Director", "Ministry" };

            // Ensure each role exists
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    Console.WriteLine($"Role {role} created.");
                }

                else
                {
                    Console.WriteLine($"Role {role} already exists.");
                }
            }
           

        }
    }
}
