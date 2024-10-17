using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using BackendMagic.Model.Enums;

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

        public Teacher( string firstName, string lastName, Gender gender, Level level)
        {
       
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Level = level;
            
        }

        public Teacher( string firstName, string lastName, Gender gender, Level level, Course currentCourse)
        {
       
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Level = level;
            CurrentCourse = currentCourse;

        }


        // A teacher has many TeacherGrade (the join table) // az osztályért ahol tanít
        public List<TeacherGrade> TeacherGrades { get; set; }


        // var gradesForATeacher = teacher.TeacherGrades.Select(tg => tg.Grade).ToList();
        // public List<Grade> Grades { get; set; } helyett




















        public void AppointToHeadMaster()
        {
            // Check if the teacher is already a headmaster
            if (this.Level == Level.Headmaster)
            {
                // Optionally throw an exception or handle the case here
                throw new InvalidOperationException("This teacher is already the headmaster.");
            }

            this.Level = Level.Headmaster;

        }

        public void DownGradeToTeacher()
        {



            // Check if the teacher is already a headmaster
            if (this.Level == Level.Teacher)
            {
                // Optionally throw an exception or handle the case here
                throw new InvalidOperationException("This teacher is not a headmaster.");
            }


            this.Level = Level.Teacher;

        }

    }
 }
    