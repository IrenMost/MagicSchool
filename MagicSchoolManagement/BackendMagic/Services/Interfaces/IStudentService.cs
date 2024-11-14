using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<Student> UpdateStudent(Student student);
        Task<Student> GivePetToStudentById(int studentId, Pet pet);
        Task<Student> RankAStudentByIdIntoAHouse(int studentId, int houseid);
        Task<Student> AddCourseToAStudent(int studnetId, Course course, bool IsAdd);

        Task<Student> UpdateStudentWithRoom(int studentId, int roomId);

        Task<Student> UpdateStudentIntoAGrade(int studentId, int gradeId);
    }
}
