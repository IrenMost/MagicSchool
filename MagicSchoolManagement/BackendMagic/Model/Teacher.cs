using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using BackendMagic.Model.Enums;
using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        
        public Level Level{ get; set; } // if director 2, headmaster 1, otherwise 0
        
        public Course CurrentCourse { get; set; } = Course.None;

        // Foreign key and navigation property for IdentityUser
        public string IdentityUserId { get; set; } // The foreign key to IdentityUser
        public IdentityUser IdentityUser { get; set; } // Navigation property

       

        public Teacher( string firstName, string lastName, Gender gender, Level level, Course currentCourse, string identityUserId)
        {
       
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Level = level;
            CurrentCourse = currentCourse;
            IdentityUserId = identityUserId;

        }


        // A teacher has many TeacherGrade (the join table) // az osztályért ahol tanít
        public List<TeacherGrade> TeacherGrades { get; set; }


        // var gradesForATeacher = teacher.TeacherGrades.Select(tg => tg.Grade).ToList();
        // public List<Grade> Grades { get; set; } helyett



    }
 }
    