using System.ComponentModel.DataAnnotations;

namespace BackendMagic.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
