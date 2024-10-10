using BackendMagic.Model.Enums;
using System.Numerics;

namespace BackendMagic.Model
{
    public class Grade
    {
        public int GradeId { get; set; }
        public GradeType GradeType { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public List<Course> ChooseableCourses { get; set; } = new List<Course>();

        // A grade has many TeacherGrade (the join table)
        public List<TeacherGrade> TeacherGrades { get; set; } // a tanárért, aki ott tanít

        // var teachersForGrade = grade.TeacherGrades.Select(tg => tg.Teacher).ToList();
        // public List<Teacher> Teachers { get; set; } helyett
    }
}
