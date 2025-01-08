
using BackendMagic.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BackendMagic.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseEnumController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<List<string>> GetAllCourses()
        {
           
            var courses = Enum.GetValues(typeof(Course))
                              .Cast<Course>()
                              .Select(c => c.ToString())
                              .ToList();

            return Ok(courses);
        }
    }
   
}
