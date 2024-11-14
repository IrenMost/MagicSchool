using BackendMagic.Model;
using BackendMagic.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BackendMagic.DTOs.Auth
{
    public class RegisterAStudentDto
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

        public Pet Pet { get; set; }
        public  GradeType GradeType{ get; set; }

        public HouseName HouseName { get; set; }
    }
}
