using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;

namespace BackendMagic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IStudentRepository _studentRepository;
        public Task<Student> AddCourseToAStudent(int studnetId, Course course, bool IsAdd)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GivePetToStudentById(int studentId, Pet pet)
        {
            throw new NotImplementedException();
        }

        public Task<Student> RankAStudentByIdIntoAHouse(int studentId, int houseid)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudentIntoAGrade(int studentId, Grade grade)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudentWithRoom(int studentId, int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
