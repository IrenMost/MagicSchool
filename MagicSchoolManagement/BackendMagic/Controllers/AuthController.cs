using BackendMagic.DTOs.Auth;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Authentication;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BackendMagic.Model;
using BackendMagic.Services.Authentication.Token;
using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ITeacherService _teacherService;
        private readonly IHouseElfRepository _houseElfRepository;
        private readonly IHouseElfService _houseElfService;
        private readonly IAuthService _authService;
        private readonly ITokenManager _tokenManager;
        private readonly UserManager<IdentityUser> _userManager;



        public AuthController(IStudentService studentService, IStudentRepository studentRepository, ITeacherRepository teacherRepository, ITeacherService teacherService, IHouseElfRepository houseElfRepository, IHouseElfService houseElfService, IAuthService authService, ITokenManager tokenManager, UserManager<IdentityUser> userManager)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _teacherService = teacherService;
            _houseElfRepository = houseElfRepository;
            _houseElfService = houseElfService;
            _authService = authService;
            _tokenManager = tokenManager;
            _userManager = userManager;
        }

        [HttpPost("registerAStudent")]
        public async Task<IActionResult> RegisterAStudent([FromBody] RegisterAStudentDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterStudentAsync(model);

            if (result.Succeeded)
            {

                return Ok("Identityuser and Student entity registered successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("registerAHouseElf")]
        public async Task<IActionResult> RegisterAHouseElf([FromBody] RegisterHouseElfDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterHouseElf(model);

            if (result.Succeeded)
            {

                return Ok("Identityuser and HouseElf entity registered successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("registerATeacher")]
        public async Task<IActionResult> RegisterATeacher([FromBody] RegisterATeacherDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterTeacherAsync(model);

            if (result.Succeeded)
            {

                return Ok("Identityuser and Teacher entity registered successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {

            Console.WriteLine(model.Email);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.GetUserId(model);
           

            if (token != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // For local development only; set to true in production
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                };

                Response.Cookies.Append("jwt", token, cookieOptions);

                var entity = await _authService.FindEntity(model);

                // Await FindEntity to retrieve the user type and entity data
               
                if (entity != null)
                {
                    if (entity.UserType == "Teacher")
                    {
                        // Retrieve additional teacher details
                        var teacherUser = await _userManager.FindByEmailAsync(model.Email);

                        var userData = await _teacherRepository.GetTeacherByIdentityUserId(teacherUser.Id);

                        if (userData != null)
                        {
                            return Ok(userData);
                        }
                    }
                    else if (entity.UserType == "Student")
                    {
                        var studentUser = await _userManager.FindByEmailAsync(model.Email);

                        var userData = await _studentRepository.GetStudentByIdentityUserId(studentUser.Id);
                        return Ok(new { Message = "Logged in as Student", userData });
                    }
                    else if (entity.UserType == "HouseElf")
                    {
                        var houseElfUser = await _userManager.FindByEmailAsync(model.Email);

                        var userData = await _houseElfRepository.GetHouseElfByIdentityUserId(houseElfUser.Id);
                        return Ok(new { Message = "Logged in as HouseElf", userData });
                    }
                }
                else
                {
                    return Unauthorized("User type not found.");
                }
            }

            return Unauthorized("Invalid username or password.");
        }



        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (Request.Cookies["jwt"] != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(-1)
                };

                Response.Cookies.Append("jwt", "", cookieOptions);
            }

            return Ok("Logout successful.");
        }
    }
}



