using BackendMagic.DTOs;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Services;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendMagic.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly ILogger<GradeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IGradeService _gradeService; 
        private readonly IStudentService _studentService;

        public GradeController(ILogger<GradeController> logger, IConfiguration configuration, IGradeService gradeService, IStudentService studentService)
        {
            _logger = logger;
            _configuration = configuration;
            _gradeService = gradeService;
            _studentService = studentService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Grade>>> Get7Grades()
        {
            try
            {
                var grades = await _gradeService.GetAllGrades();
                if (grades == null || grades.Count == 0)
                {
                    return NotFound("No houses were found.");
                }
                var gradeDtos = new List<GradeDto>();

               
                foreach (var grade in grades)
                {
                    var gradeDto = new GradeDto
                    {
                       GradeId = grade.GradeId,
                       GradeType = grade.GradeType.ToString(),
                       ChooseableCourses = grade.ChooseableCourses,
                    };

                    
                    gradeDtos.Add(gradeDto);
                }

               
                return Ok(gradeDtos);




            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching grades");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{gradeId}")]
        public async Task<ActionResult<Grade>> GetGradeById(int gradeId)
        {
            var grade = await _gradeService.GetGradeById(gradeId);
            if (grade == null)
            {
                return NotFound("No grade found.");
            }

            

            var gradeDto = new GradeDto
            {
                GradeId = grade.GradeId,
                GradeType = grade.GradeType.ToString(),
                ChooseableCourses = grade.ChooseableCourses,


            };
            return Ok(gradeDto);
        }


        [HttpPatch("updateCourseListAdd/{gradeId}")]
        public async Task<ActionResult<Grade>> UpdateCourseListAdd(int gradeId, [FromBody] Course course) // should be a number, for it is an enum
        {
            try
            {
                var grade = await _gradeService.AddCourseToAGrade(gradeId, course);

                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("updateCourseListRemove/{gradeId}")]
        public async Task<ActionResult<Grade>> UpdateCourseListRemove(int gradeId, [FromBody] Course course)
        {
            try
            {
                var grade = await _gradeService.RemoveCourseFromAGrade(gradeId, course);

                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
