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

        public async Task<Grade> AddCourseToAGrade(int gradeId, Course course) // int teacher
        {

            var grade = await _gradeRepository.GetGradeById(gradeId);
            grade.ChooseableCourses.Add(course);
           
            await _gradeRepository.UpdateGrade(grade);
            return grade;
            
        }

        //nem kell mégegyszer eltárolni, mert lekérhető lesz a studentnél...

        public async Task<Grade> AddStudentTotheFirstGrade( int studentId)
        {
            var grade = await _gradeRepository.GetGradeById(1);
            var student = await _studentRepository.GetStudentById(studentId);

            grade.Students.Add(student);
            student.GradeId = 1;

            await _studentRepository.UpdateStudent(student);
            await _gradeRepository.UpdateGrade(grade);

            return grade;
        }

        public async Task<Grade> RemoveCourseFromAGrade(int gradeId, Course course)
        {
            var grade = await _gradeRepository.GetGradeById(gradeId);
            grade.ChooseableCourses.Remove(course);

            await _gradeRepository.UpdateGrade(grade);
            return grade;
        }

        public async Task LetAStudentStepAGradeForward(int studentId, int currentGradeId)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            var currentGrade = student.Grade;
            var nextGradeId = currentGradeId +1;
           

            if (student == null)
            {   
                throw new KeyNotFoundException("no such studnet ");
            }

            if(student.GradeId == 7)
            {
                throw new Exception("School is finished by this year");
            } else
            {
                var nextGrade = await _gradeRepository.GetGradeById(nextGradeId);
                student.GradeId = currentGradeId + 1;
                currentGrade.Students.Remove(student);
                nextGrade.Students.Add(student);

            }
        }
    }
}
