using BackendMagic.DTOs.Auth;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Authentication.Token;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace BackendMagic.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenManager _tokenManager;
        private readonly IHouseElfRepository _houseElfRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IGradeRepository _gradeRepository;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IHouseElfRepository houseElfRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository, ITokenManager tokenManager, IHouseRepository houseRepository, IGradeRepository gradeRepository )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenManager = tokenManager;
            _houseElfRepository = houseElfRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _houseRepository = houseRepository;
            _gradeRepository = gradeRepository;
        }

        public async Task<LoginEntity?> FindEntity(LoginDto loginDto)
        {
          
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return null; // Email not found
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                return null; // Invalid password
            }

            // Determine which type of entity the user is (student, houseelf or teacher
            var student = await _studentRepository.GetStudentByIdentityUserId(user.Id);
            if (student != null)
            {
                return new LoginEntity("Student", student);
            }

            var teacher = await _teacherRepository.GetTeacherByIdentityUserId(user.Id);
            if (teacher != null)
            {
                return new LoginEntity("Teacher", teacher);
            }

            var houseElf = await _houseElfRepository.GetHouseElfByIdentityUserId(user.Id);
            if (houseElf != null)
            {
                return new LoginEntity("HouseElf", houseElf);
            }

            return null; // No matching entity
        }

        public async Task<string?> GetUserId(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) { return null; }
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (result)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return _tokenManager.GenerateToken(user, roles);
                }
            }
            return null;

        }
        public async Task<IdentityResult> RegisterHouseElf(RegisterHouseElfDto registerHouseElfDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerHouseElfDto.Email);
            if (existingUser != null) {
                return IdentityResult.Failed(new IdentityError { Description = "Email already taken" });
            };
            var houseElfUser = new IdentityUser {  UserName = registerHouseElfDto.UserName, Email = registerHouseElfDto.Email };

            var result = await _userManager.CreateAsync( houseElfUser, registerHouseElfDto.Password);
            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(houseElfUser, registerHouseElfDto.Role);
            }
            if(houseElfUser.Id == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "id null." });
            }
            var persistedUser = await _userManager.FindByIdAsync(houseElfUser.Id);

            if (persistedUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Failed to persist user." });
            }
            var houseElf = new HouseElf { Name = registerHouseElfDto.Name, IdentityUserId = houseElfUser.Id };
            await _houseElfRepository.AddAsync(houseElf);
            return result;
        }

        public async Task<IdentityResult> RegisterStudentAsync(RegisterAStudentDto registerStudentDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerStudentDto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email already taken" });
            };
            var studentUser = new IdentityUser { UserName = registerStudentDto.UserName, Email = registerStudentDto.Email };

            var result = await _userManager.CreateAsync(studentUser, registerStudentDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(studentUser, registerStudentDto.Role);
            }

            if (studentUser.Id == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "no user still" });
            }

            var persistedUser = await _userManager.FindByIdAsync(studentUser.Id);

            if (persistedUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Failed to persist user." });
            }

         
            var houseId = registerStudentDto.HouseId;
            var house = await _houseRepository.GetHouseById(houseId);
            var student = new Student(
                        registerStudentDto.FirstName,
                        registerStudentDto.LastName,
                        registerStudentDto.Gender,
                        registerStudentDto.Pet,
                        registerStudentDto.GradeId,
                        registerStudentDto.HouseId,
                        studentUser.Id
                    );
            await _studentRepository.AddAsync(student);
            return result;
        }

        public async Task<IdentityResult> RegisterTeacherAsync(RegisterATeacherDto registerTeacherDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerTeacherDto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email already taken" });
            }

            var teacherUser = new IdentityUser { UserName = registerTeacherDto.UserName, Email = registerTeacherDto.Email };

            var result = await _userManager.CreateAsync(teacherUser, registerTeacherDto.Password);

           
            if (result.Succeeded)
            {
               
                await _userManager.AddToRoleAsync(teacherUser, registerTeacherDto.Role ?? "Teacher"); 

                
                var teacher = new Teacher
                (
                    registerTeacherDto.FirstName,
                    registerTeacherDto.LastName,
                    registerTeacherDto.Gender,
                    registerTeacherDto.Level, 
                   registerTeacherDto.Course,
                    teacherUser.Id
                );
                await _teacherRepository.AddAsync(teacher);
            }

            return result;
        }
    }
}
