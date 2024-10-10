using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Repository.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers();
        Task AddAsync(Teacher teacher);

        Task<Teacher> GetTeacherById(int teacherId);
        Task UpdateCurrentCourse(Course course);
        Task UpdateAllCourses(Course course);
       
      

        
    }
}
