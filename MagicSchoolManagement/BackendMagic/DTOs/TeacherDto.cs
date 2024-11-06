using BackendMagic.Model.Enums;

namespace BackendMagic.DTOs
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public Gender Gender { get; set; }
        public string Fullname { get; set; }
        public string Level { get; set; } // if director 2, headmaster 1, otherwise 0

        public string CurrentCourse { get; set; } 
    }
}
