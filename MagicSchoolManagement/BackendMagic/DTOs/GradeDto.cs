using BackendMagic.Model.Enums;
using BackendMagic.Model;

namespace BackendMagic.DTOs
{
    public class GradeDto
    {
        public int GradeId { get; set; }
        public string GradeType { get; set; } // pl first
        public List<Student> Students { get; set; } = new List<Student>();

        public List<Course> ChooseableCourses { get; set; } = new List<Course>();

        

      
    }
}
