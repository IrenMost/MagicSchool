using BackendMagic.Model.Enums;
using BackendMagic.Model;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BackendMagic.DTOs.Auth
{
    public class RegisterATeacherDto
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public Level Level { get; set; } = Level.Teacher;

        public Course Course { get; set; }

        public string Role { get; set;  } = "Teacher";



    }
}
