using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.Identity.Client;

namespace BackendMagic.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;

        public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<Grade>> GetAllGrades()
        {
            return await _gradeRepository.GetGrades();
        }

        public async Task<Grade> GetGradeById(int gradeId)
        {
            return await _gradeRepository.GetGradeById(gradeId);
        }

        public async Task<Grade> AddCourseToAGrade(int gradeId, Course course)
        {

            var grade = await _gradeRepository.GetGradeById(gradeId);
            grade.ChooseableCourses.Add(course);
           
            await _gradeRepository.UpdateGrade(grade);
            return grade;
            
        }

        public async Task<Grade> AddStudentToAGrade(int gradeId, int studentId)
        {
            var grade = await _gradeRepository.GetGradeById(gradeId);
            var student = await _studentRepository.GetStudentById(studentId);

            grade.Students.Add(student);
            student.GradeId = gradeId;

            await _studentRepository.UpdateStudent(student);
            await _gradeRepository.UpdateGrade(grade);

            return grade;
        }
    }
}
