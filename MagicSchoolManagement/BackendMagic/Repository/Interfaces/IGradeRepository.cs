using BackendMagic.Model;
using System.Threading.Tasks;

namespace BackendMagic.Repository.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetGrades();
        Task<Grade> GetGradeById(int gradeId);

        Task AddGradeAsync(Grade grade);
        Task UpdateGrade(Grade grade);

        Task SaveChangesAsync();
    }
}
