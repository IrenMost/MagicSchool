using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public TeacherService(ITeacherRepository teacherRepository, UserManager<IdentityUser> userManager)
        {
            _teacherRepository = teacherRepository;
            _userManager = userManager;

        }
        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _teacherRepository.GetAllTeachers();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _teacherRepository.GetTeacherById(teacherId);
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            await _teacherRepository.UpdateTeacher(teacher);
            return teacher;
        }

        public async Task<Teacher> UpdateCourse(int teacherId, Course course)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);
            if (teacher == null)
            {
                throw new KeyNotFoundException("no such teacher ");
            }
            teacher.CurrentCourse = course;
           
           await _teacherRepository.UpdateTeacher(teacher);
            return teacher;
        }

        public async Task<Teacher> UpdateLevelByTeacherId(int teacherId, Level level)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);
            if (teacher == null)
            {
                throw new KeyNotFoundException("no such teacher ");
            }

            teacher.Level = level;
            await _teacherRepository.UpdateTeacher(teacher);
            return teacher;
        }

       
      

     


    }
}
