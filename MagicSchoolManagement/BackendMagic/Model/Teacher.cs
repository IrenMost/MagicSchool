using System.Security.Cryptography.X509Certificates;
using BackendMagic.Model.Enums;

namespace BackendMagic.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public List<Course> AbleToTeachCourses { get; set; }
        public Course CurrentCourse { get; set; }

        public Level Level{ get; set; } // if headmaster 1, otherwise 0



        public bool isHeadMaster() 
        {
            return this.Level == Level.Headmaster;
        }

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
    