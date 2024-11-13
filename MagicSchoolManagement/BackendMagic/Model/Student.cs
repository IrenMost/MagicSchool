using BackendMagic.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace BackendMagic.Model
{
    public class Student
    {
        

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Pet Pet { get; set; }
       
       

        public List<Course> MyCourses { get; set; } = new List<Course>();
       

        // Navigation properties
        public int HouseId { get; set; }
        public virtual House House { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }


        public int GradeId { get; set; }    
        public virtual Grade Grade { get; set; }

        // Foreign key and navigation property for IdentityUser
        public string IdentityUserId { get; set; } // The foreign key to IdentityUser
        public IdentityUser IdentityUser { get; set; } // Navigation property

        public Student(string firstName, string lastName, Gender gender, Pet pet, int houseId, int roomId, int gradeId, string identityUserId)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Pet = pet;
            HouseId = houseId;
            RoomId = roomId;
            GradeId = gradeId;
            IdentityUserId = identityUserId;
        }

        public Student(string firstName, string lastName, Gender gender, Pet pet, string identityUserId)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Pet = pet;
            IdentityUserId = identityUserId;
        }

        public Student(string firstName, string lastName, Gender gender, Pet pet, int houseId, int gradeId, string identityUserId)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Pet = pet;
            HouseId = houseId;
            GradeId = gradeId;
            IdentityUserId = identityUserId;
        }


    }
}
