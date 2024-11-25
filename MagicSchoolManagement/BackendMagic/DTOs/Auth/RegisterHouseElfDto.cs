using System.ComponentModel.DataAnnotations;

namespace BackendMagic.DTOs.Auth
{
    public class RegisterHouseElfDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; } // "dobby"

        public string Role { get; } = "HouseElf";


    }
}
