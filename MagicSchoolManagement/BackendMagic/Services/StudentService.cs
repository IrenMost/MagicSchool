using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Services.Interfaces;

namespace BackendMagic.Services
{
    public class StudentService : IStudentService
    {
        public Task<List<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateCourses(int studnetId, Course course, bool IsAdd)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateGrade(int studentId, Grade grade)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateHouse(int studentId, int houseid)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdatePet(int studentId, Pet pet)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateRoom(int studentId, int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
