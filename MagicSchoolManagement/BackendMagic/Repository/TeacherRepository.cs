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

            try
            {
                return await _dbContext.Teachers.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions, possibly log them
                throw new Exception("An error occurred while retrieving teachers.", ex);
            }
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(h => h.TeacherId == teacherId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

  
        public async Task UpdateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Update(teacher);
            await _dbContext.SaveChangesAsync();

        }
    }
}
