//using BackendMagic.Model.Enums;
//using BackendMagic.Model;
//using BackendMagic.Repository.Interfaces;
//using BackendMagic.Repository;
//using Microsoft.AspNetCore.Identity;
//using System.Data;
//using System.Drawing;
//using System.Reflection;
//using BackendMagic.Data.SeedingDto;

//namespace BackendMagic.Data
//{
//    public class HelpStudentSeeder
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly IStudentRepository _studentRepository;
//        private readonly IRoomRepository _roomRepository;


//        public async Task EnsureStudentsAsync(List<StudentData> students)
//        {
//            foreach (var studentData in students)
//            {
//                await EnsureStudentsAsync(
//                    studentData.UserName,
//                    studentData.Email,
//                    studentData.Password,
//                   studentData.FirstName,
//                    studentData.LastName,
//                    studentData.Gender,
//                    studentData.Pet,
//                    studentData.HouseId,
//                    studentData.RoomId,
//                    studentData.GradeId,
//                    studentData.Role
                    
//                );
//            }
//        }
//        public  async Task EnsureStudentsAsync(
//                string userName,
//                string email,
//                string password,
//                string firstName,
//                string lastName,
//                Model.Enums.Gender gender,
//                Model.Enums.Pet pet,
//                int houseId,
//                int roomId,
//                int gradeId,
//                string role = "Student")
//        {
//            // Check if IdentityUser exists
//            var user = await _userManager.FindByNameAsync(userName);
//            if (user == null)
//            {
//                user = new IdentityUser { UserName = userName, Email = email };
//                var result = await _userManager.CreateAsync(user, password);

//                user.EmailConfirmed = true;
//                await _userManager.UpdateAsync(user);

//                if (result.Succeeded)
//                {
//                    await _userManager.AddToRoleAsync(user, role);
//                }
//            }

//            // Check if Student entity exists
//            if ((await _studentRepository.GetStudentByIdentityUserId(user.Id)) == null)
//            {
//                // Create the Student entity
//                var student = new Student(
//                                firstName: firstName,
//                                lastName: lastName,
//                                gender: gender,
//                                pet: pet,
//                                houseId: houseId,
//                                roomId: roomId,
//                                gradeId: gradeId,
//                                identityUserId: user.Id
//    );


//                await _studentRepository.AddAsync(student);

//                // put student into the large room( roomId = 1);

//                await _roomRepository.AddStudentToARoom(student, 1);
//            }
//        }

       

//}
//}