using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int teacherId);
        Task<Teacher> GetTeacherByIdentityUserId(string identityUserId);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<Teacher> UpdateCourse(int teacherId, Course course);
        //Task<TeacherGrade> UpdateGradesThatAreToughtTeacherId(int teacherId, int gradeId);
        Task<Teacher> UpdateByAddingRoleToATeacherByIdentityUserId(string identitiyUserId, string role);

        Task<Teacher> RemoveRoleFromATeacherByIdentityUserId(string identitiyUserId, string role);
    }
}
