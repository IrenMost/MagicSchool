using BackendMagic.Model;

namespace BackendMagic.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int teacherId);
    }
}
