using BackendMagic.Model;
using BackendMagic.Services.Interfaces;

namespace BackendMagic.Services
{
    public class TeacherService : ITeacherService
    {
        public Task<List<Teacher>> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetTeacherById(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
