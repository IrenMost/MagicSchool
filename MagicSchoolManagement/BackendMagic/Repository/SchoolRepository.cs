using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using System.Data.Entity;

namespace BackendMagic.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolContext _dbContext;

        public SchoolRepository(SchoolContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task AddAsync(School school)
        {
            await _dbContext.Schools.AddAsync(school);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<School> GetSchoolById(int schoolId)
        {
            return await _dbContext.Schools.FirstOrDefaultAsync(s => s.SchoolId == schoolId);
        }

        public async Task<List<School>> GetSchools()
        {
            return await _dbContext.Schools.ToListAsync();
        }
    }
}
