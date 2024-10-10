using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackendMagic.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private SchoolContext _dbContext;

        public TeacherRepository(SchoolContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _dbContext.AddAsync(teacher);
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _dbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(h => h.TeacherId == teacherId);
        }

        public async Task UpdateAllCourses(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCurrentCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
