using BackendMagic.DTOs;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendMagic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHouseService _houseService; 
        private readonly ITeacherService _teacherService;

        public TeacherController(ILogger<TeacherController> logger, IConfiguration configuration, IHouseService houseService, ITeacherService teacherService)
        {
            _logger = logger;
            _configuration = configuration;
            _houseService = houseService;
            _teacherService = teacherService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetAllTeachers();
              
                if (teachers == null || teachers.Count == 0)
                {
                    return NotFound("No teachers were found.");
                }
                var teacherDtos = new List<TeacherDto>();

               
                foreach (var teacher in teachers)
                {
                    var teacherDto = new TeacherDto
                    {
                        TeacherId = teacher.TeacherId,
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        Gender = teacher.Gender,
                        Fullname = teacher.FirstName + " " + teacher.LastName,
                        Level = teacher.Level.ToString(),
                        CurrentCourse = teacher.CurrentCourse.ToString(),
                    };

                   
                    teacherDtos.Add(teacherDto);
                }

              
                return Ok(teacherDtos);

    }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching teachers");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int teacherId)
        {
            var teacher = await _teacherService.GetTeacherById(teacherId);
           
            if (teacher == null)
            {
                return NotFound("No teacher found.");
            }

           
            var teacherDto = new TeacherDto
            {


                TeacherId = teacher.TeacherId,
                FirstName = teacher.FirstName,
                LastName = teacher.FirstName,
                Gender = teacher.Gender,
                Fullname = teacher.FirstName + teacher.FirstName,
                Level = teacher.Level.ToString(),
                CurrentCourse = teacher.CurrentCourse.ToString(),
            };
            return Ok(teacherDto);
        }

        [HttpPatch("updateTeacherCourse/{teacherId}")]
        public async Task<ActionResult<House>> UpdateCourse(int teacherId, Course course)
        {
            try
            {
                var teacher = await _teacherService.UpdateCourse(teacherId, course);

                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }


}
