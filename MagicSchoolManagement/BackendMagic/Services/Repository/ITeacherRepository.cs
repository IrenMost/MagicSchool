using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Services.Repository
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        void AddTeacher(Teacher teacher);

        Teacher? GetTeacherById(int TeacherId);
        void UpdateCurrentCourse(Course course);
        

        void UpdateAllCourses(Course course);

    }
}
