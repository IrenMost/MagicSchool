using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendMagic.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolContext _dbContext;

        public GradeRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGradeAsync(Grade grade)
        {
            await _dbContext.Grade.AddAsync(grade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Grade> GetGradeById(int gradeId)
        {
            return await _dbContext.Grade.FirstOrDefaultAsync(g => g.GradeId ==gradeId);
        }

        public async Task<List<Grade>> GetGrades()
        {
            return await _dbContext.Grade.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGrade(Grade grade)
        {
            _dbContext.Grade.Update(grade);
            await _dbContext.SaveChangesAsync();
        }
    }
}
