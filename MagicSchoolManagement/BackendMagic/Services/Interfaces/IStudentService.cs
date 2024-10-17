using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<Student> UpdateStudent(Student student);
        Task<Student> UpdatePet(int studentId, Pet pet);
        Task<Student> UpdateHouse(int studentId, int houseid);
        Task<Student> UpdateCourses(int studnetId, Course course, bool IsAdd);

        Task<Student> UpdateRoom(int studentId, int roomId);

        Task<Student> UpdateGrade(int studentId, Grade grade);
    }
}
