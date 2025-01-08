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


        public HouseElf(int houseElfId, string name, string identityUserId, IdentityUser identityUser)
        {
            HouseElfId = houseElfId;
            Name = name;
            IdentityUserId = identityUserId;
            IdentityUser = identityUser;
        }
        public HouseElf( string name, string identityUserId )
        {
            
            Name = name;
            IdentityUserId = identityUserId;
           
        }

        public HouseElf()
        {
        }
    }

}
