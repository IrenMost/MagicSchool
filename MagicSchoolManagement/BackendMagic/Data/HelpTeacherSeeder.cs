//using BackendMagic.Data.SeedingDto;
//using BackendMagic.DTOs;
//using BackendMagic.Model;
//using BackendMagic.Repository.Interfaces;
//using Microsoft.AspNetCore.Identity;

//namespace BackendMagic.Data
//{
//    public class HelpTeacherSeeder
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly ITeacherRepository _teacherRepository;

//        public HelpTeacherSeeder(UserManager<IdentityUser> userManager, ITeacherRepository teacherRepository)
//        {
//            _userManager = userManager;
//            _teacherRepository = teacherRepository;
//        }

//        public async Task EnsureTeachersAsync(List<TeacherData> teachers)
//        {
//            foreach (var teacherData in teachers)
//            {
//                await EnsureTeacherAsync(
//                    teacherData.UserName,
//                    teacherData.Email,
//                    teacherData.Password,
//                    teacherData.FirstName,
//                    teacherData.LastName,
//                    teacherData.Gender,
//                    teacherData.Level,
//                    teacherData.Course,
//                    teacherData.Role
//                );
//            }
//        }

//        private async Task EnsureTeacherAsync(
//            string userName,
//            string email,
//            string password,
//            string firstName,
//            string lastName,
//            Model.Enums.Gender gender,
//            Model.Enums.Level level,
//            Model.Enums.Course course,
//            string role = "Teacher")
//        {
//            var user = await _userManager.FindByNameAsync(userName);
//            if (user == null)
//            {
//                user = new IdentityUser { UserName = userName, Email = email };
//                var result = await _userManager.CreateAsync(user, password);
//                if (result.Succeeded)
//                {
//                    await _userManager.AddToRoleAsync(user, role);

//                    user.EmailConfirmed = true;
//                    await _userManager.UpdateAsync(user);
//                    if (level == Model.Enums.Level.Headmaster)
//                    {
//                        await _userManager.AddToRoleAsync(user, "Headmaster");
//                    }
//                    if (level == Model.Enums.Level.Director)
//                    {
//                        await _userManager.AddToRoleAsync(user, "Director");
//                    }
//                }
//            }

//            if ((await _teacherRepository.GetTeacherByIdentityUserId(user.Id)) == null)
//            {
//                var teacher = new Teacher(firstName, lastName, gender, level, course, user.Id);
//                await _teacherRepository.AddAsync(teacher);
//            }
//        }
//    }
//}
