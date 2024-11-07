using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Services.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade>> GetAllGrades();
        Task<Grade> GetGradeById(int gradeId);
        Task<Grade> AddCourseToAGrade(int gradeId, Course course);
        Task<Grade> AddStudentToAGrade(int gradeId, int studentId);
    }
}
