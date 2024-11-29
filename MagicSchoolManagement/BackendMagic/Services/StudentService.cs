using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public Task<Student> AddCourseToAStudent(int studnetId, Course course, bool IsAdd)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _studentRepository.GetStudentById(studentId);
        }

        public async Task<Student> GivePetToStudentById(int studentId, Pet pet)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            student.Pet = pet;
            await _studentRepository.UpdateStudent(student);
            return student;
        }

        public async Task<Student> RankAStudentByIdIntoAHouse(int studentId, int houseid)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            var house = await _houseRepository.GetHouseById(houseid);
            student.House = house;
            await _studentRepository.UpdateStudent(student);
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            await _studentRepository.UpdateStudent(student);
            return student;
        }

        public async Task<Student> UpdateStudentIntoAGrade(int studentId, int gradeId)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            var grade = await _gradeRepository.GetGradeById(gradeId);
            student.Grade = grade;
            await _studentRepository.UpdateStudent(student);
            return student;
        }

        public async Task<Student> UpdateStudentWithRoom(int studentId, int roomId)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            var room = await _roomRepository.GetRoomById(roomId);
            student.Room = room;
            await _studentRepository.UpdateStudent(student);
            return student;
        }
    }
}
