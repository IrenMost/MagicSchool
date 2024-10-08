using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BackendMagic.Services.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private SchoolContext dbContext;

        public TeacherRepository(SchoolContext context)
        {
            dbContext = context;
        }
        public void AddTeacher(Teacher teacher)
        {
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }

        

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Teacher? GetTeacherById(int TeacherId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllCourses(Course course)
        {
            throw new NotImplementedException();
        }

        public void UpdateCurrentCourse(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void UpdateCurrentCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
