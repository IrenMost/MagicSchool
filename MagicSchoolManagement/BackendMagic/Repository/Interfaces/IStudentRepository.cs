using BackendMagic.Model;

namespace BackendMagic.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);

        Task AddAsync(Student student);
        Task UpdateStudent(Student student);

        Task SaveChangesAsync();

    }
}
