using BackendMagic.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace BackendMagic.Model
{
    public class HouseElf
    {
        public int HouseElfId { get; set; }
        public string Name { get; set; }

        public string IdentityUserId { get; set; } 
        public IdentityUser IdentityUser { get; set; } 





    }

}
