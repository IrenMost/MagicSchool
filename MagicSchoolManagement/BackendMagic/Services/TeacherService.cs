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

       

        public  async Task<Teacher> GetTeacherByIdentityUserId(string identityUserId)
        {
            return await _teacherRepository.GetTeacherByIdentityUserId(identityUserId);
        }

        public async Task<Teacher> UpdateByAddingRoleToATeacherByIdentityUserId(string identitiyUserId, string role)
        {
            var teacherUser = await _userManager.FindByIdAsync(identitiyUserId);
            if (teacherUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }


            // user is already in that role?

            bool hasRole = await _userManager.IsInRoleAsync(teacherUser, role);
            if (!hasRole)
            {
                var result = await _userManager.AddToRoleAsync(teacherUser, role);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to add role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            var teacher = await _teacherRepository.GetTeacherByIdentityUserId(identitiyUserId);
            return teacher;
        }

        public async Task<Teacher> RemoveRoleFromATeacherByIdentityUserId(string identitiyUserId, string role)
        {
           
            var teacherUser = await _userManager.FindByIdAsync(identitiyUserId);
            if (teacherUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

         
            bool hasRole = await _userManager.IsInRoleAsync(teacherUser, role);
            if (hasRole)
            {
            
                var result = await _userManager.RemoveFromRoleAsync(teacherUser, role);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to remove role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

          
            var teacher = await _teacherRepository.GetTeacherByIdentityUserId(identitiyUserId);
            return teacher;
        }
    }
}
