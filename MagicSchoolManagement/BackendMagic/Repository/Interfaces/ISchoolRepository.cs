using BackendMagic.Model;

namespace BackendMagic.Repository.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetSchools(); // if not only Hogwarts exists
        Task<School> GetSchoolById(int schoolId);

        Task AddAsync(School school);
    }
}
