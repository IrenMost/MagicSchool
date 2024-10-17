using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


namespace BackendMagic.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private SchoolContext _dbContext;

        public TeacherRepository(SchoolContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(params Teacher[] teachers)
        {
            foreach (var teacher in teachers)
            {
                
                _dbContext.Teachers.Add(teacher);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            
            return await _dbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(h => h.TeacherId == teacherId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
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
