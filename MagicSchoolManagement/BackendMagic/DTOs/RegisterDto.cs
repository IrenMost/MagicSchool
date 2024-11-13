using BackendMagic.Model;
using BackendMagic.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace BackendMagic.DTOs
{
    public class RegisterDto
    {
        public class RegisterDTO
        {
            [Required]
            [StringLength(100, MinimumLength = 5)]
            public string UserName { get; set; } = string.Empty;

            
            [Required]
            [StringLength(100, MinimumLength = 6)]
            public string Password { get; set; } = string.Empty;

            [Required]
            [Compare("Password")]
            public string ConfirmPassword { get; set; } = string.Empty;

            
        }
    }
}
