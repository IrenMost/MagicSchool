using BackendMagic.Data.SeedingDto;
using BackendMagic.DTOs.Auth;
using BackendMagic.Model;
using BackendMagic.Model.Enums;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Authentication;
using BackendMagic.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace BackendMagic.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {


            var houseRepository = serviceProvider.GetService<IHouseRepository>();
            var houseElfRepository = serviceProvider.GetService<IHouseElfRepository>();
            var roomRepository = serviceProvider.GetService<IRoomRepository>();
            var teacherRepository = serviceProvider.GetService<ITeacherRepository>();
            var gradeRepository = serviceProvider.GetService<IGradeRepository>();
            var studentRepository = serviceProvider.GetService<IStudentRepository>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManagementService = serviceProvider.GetRequiredService<RoleManagementService>();
            //var helpSeedStudents = serviceProvider.GetRequiredService<HelpStudentSeeder>();
            //var helpSeedTeachers = serviceProvider.GetRequiredService<HelpTeacherSeeder>();
            //var helpSeedHouseElves = serviceProvider.GetRequiredService<HelpHouseElfSeeder>();


            

            if (houseRepository == null)
            {
                throw new InvalidOperationException("IHouseRepository is not registered in the DI container.");
            }
            if (houseElfRepository == null)
            {
                throw new InvalidOperationException("IHouseElfRepository is not registered in the DI container.");
            }
            if (roomRepository == null)
            {
                throw new InvalidOperationException("IRoomRepository is not registered in the DI container.");
            }
            if (teacherRepository == null)
            {
                throw new InvalidOperationException("ITeacherRepository is not registered in the DI container.");
            }
            if (gradeRepository == null)
            {
                throw new InvalidOperationException("IGradeRepository is not registered in the DI container.");
            }
            if (studentRepository == null)
            {
                throw new InvalidOperationException("IStudnetRepositroy is not registered in the DI container.");
            }


            // roles
            await roleManagementService.EnsureRolesAndClaimsAsync();

            // students
       
            


            // help seed teachers
            async Task EnsureTeacherAsync(UserManager<IdentityUser> userManager, ITeacherRepository teacherRepository,
            string userName,
            string email,
            string password,
            string firstName,
            string lastName,
            Model.Enums.Gender gender,
            Model.Enums.Level level,
            Model.Enums.Course course,
            string role = "Teacher")
            {
                // Check if IdentityUser exists
                var user = await userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    user = new IdentityUser { UserName = userName, Email = email };
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);

                        user.EmailConfirmed = true;
                        await userManager.UpdateAsync(user);
                        if (level == Model.Enums.Level.Headmaster)
                        {
                            await userManager.AddToRoleAsync(user, "Headmaster");
                        }
                        if (level == Model.Enums.Level.Director)
                        {
                            await userManager.AddToRoleAsync(user, "Director");
                        }
                    }
                }

                // Check if Teacher entity exists
                if ((await teacherRepository.GetTeacherByIdentityUserId(user.Id)) == null)
                {
                    var teacher = new Teacher(firstName, lastName, gender, level, course, user.Id);
                    await teacherRepository.AddAsync(teacher);
                }
            }


            
            

            var teachers = await teacherRepository.GetAllTeachers();

            if (teachers.Count() == 0)
            {
                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "SeverusSnape",
                    email: "severus.snape@hogwarts.edu",
                    password: "SnapePassword123!",
                    firstName: "Severus",
                    lastName: "Snape",
                    gender: Model.Enums.Gender.Male,
                    level: Model.Enums.Level.Headmaster,
                    course: Model.Enums.Course.None,
                    role: "Teacher");

                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "AlbusDumbledore",
                    email: "albus.dumbledore@hogwarts.edu",
                    password: "DumbledorePassword123!",
                    firstName: "Albus",
                    lastName: "Dumbledore",
                    gender: Model.Enums.Gender.Male,
                    level: Model.Enums.Level.Director,
                     course: Model.Enums.Course.None,
                    role: "Teacher");

                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "MinervaMcGonagall",
                    email: "minerva.mcgonagall@hogwarts.edu",
                    password: "McGonagallPassword123!",
                    firstName: "Minerva",
                    lastName: "McGonagall",
                    gender: Model.Enums.Gender.Female,
                    level: Model.Enums.Level.Headmaster,
                    course: Model.Enums.Course.Transfiguration,
                    role: "Teacher");

                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "PomonaSprout",
                    email: "pomona.sprout@hogwarts.edu",
                    password: "SproutPassword123!",
                    firstName: "Pomona",
                    lastName: "Sprout",
                    gender: Model.Enums.Gender.Female,
                    level: Model.Enums.Level.Headmaster,
                    course: Model.Enums.Course.Herbology,
                    role: "Teacher");

                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "FiliusFlitwick",
                    email: "filius.flitwick@hogwarts.edu",
                    password: "FlitwickPassword123!",
                    firstName: "Filius",
                    lastName: "Flitwick",
                    gender: Model.Enums.Gender.Male,
                    level: Model.Enums.Level.Headmaster,
                    course: Model.Enums.Course.Charms,
                    role: "Teacher");

                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "RolandaHooch",
                    email: "rolanda.hooch@hogwarts.edu",
                    password: "HoochPassword123!",
                    firstName: "Rolanda",
                    lastName: "Hooch",
                    gender: Model.Enums.Gender.Female,
                    level: Model.Enums.Level.Teacher,
                    course: Model.Enums.Course.Flying,
                    role: "Teacher");

                await EnsureTeacherAsync(userManager, teacherRepository,
                    userName: "SybillTrelawney",
                    email: "sybill.trelawney@hogwarts.edu",
                    password: "TrelawneyPassword123!",
                    firstName: "Sybill",
                    lastName: "Trelawney",
                    gender: Model.Enums.Gender.Female,
                    course: Model.Enums.Course.None,
                    level: Model.Enums.Level.Teacher,
                    role: "Teacher");

                var houses = await houseRepository.GetHouses();

                if (houses.Count == 0)
                {

                    var house1 = new House(Model.Enums.HouseName.Gryffindor, 15, 3);
                    var house2 = new House(Model.Enums.HouseName.Hufflepuff, 15, 4);
                    var house3 = new House(Model.Enums.HouseName.Ravenclaw, 15, 5);
                    var house4 = new House(Model.Enums.HouseName.Slytherin, 15, 1);

                    await houseRepository.AddAsync(house1);
                    await houseRepository.AddAsync(house2);
                    await houseRepository.AddAsync(house3);
                    await houseRepository.AddAsync(house4);

                }
            }





                var grades = await gradeRepository.GetGrades();
            if (grades.Count == 0)
            {
                var grade1 = new Grade(Model.Enums.GradeType.first);
                var grade2 = new Grade(Model.Enums.GradeType.second);
                var grade3 = new Grade(Model.Enums.GradeType.third);
                var grade4 = new Grade(Model.Enums.GradeType.fourth);
                var grade5 = new Grade(Model.Enums.GradeType.fifth);
                var grade6 = new Grade(Model.Enums.GradeType.sixth);
                var grade7 = new Grade(Model.Enums.GradeType.seventh);

                await gradeRepository.AddGradeAsync(grade1);
                await gradeRepository.AddGradeAsync(grade2);
                await gradeRepository.AddGradeAsync(grade3);
                await gradeRepository.AddGradeAsync(grade4);
                await gradeRepository.AddGradeAsync(grade5);
                await gradeRepository.AddGradeAsync(grade6);
                await gradeRepository.AddGradeAsync(grade7);


            }


            // seed rooms 1 large and 4 for each houses

            if (roomRepository == null)
            {
                throw new InvalidOperationException("IRoomRepository is not registered in the DI container.");
            }

            var rooms = await roomRepository.GetRooms();
            if (rooms.Count == 0)
            {
                
                var largeRoom = new Room
                {
                    MaxCapacity = 200,
                    HouseId = 3 // RavenClaw is the most wellcoming house
                };
                await roomRepository.AddRoomAsync(largeRoom);

                // add 4 for each houses
                var houses = await houseRepository.GetHouses();

                if (houses != null && houses.Count > 0)
                {
                    foreach (var house in houses)
                    {
                        for (int i = 0; i < 4; i++) 
                        {
                            var smallRoom = new Room
                            {
                                MaxCapacity = 4,
                                HouseId = house.HouseId
                            };
                            await roomRepository.AddRoomAsync(smallRoom);
                        }
                    }
                }
            }
        }


        public static List<StudentData> Students => new List<StudentData>
    {
        new StudentData
        {
            UserName = "HarryPotter",
            Email = "HarryPotter@hogwarts.edu",
            Password = "PotterPassword123!",
            FirstName = "Harry",
            LastName = "Potter",
            Gender = Model.Enums.Gender.Male,
            Pet = Model.Enums.Pet.Owl,
            HouseId = 1,
            RoomId = 1,
            GradeId = 2,
            Role = "Student"
        }
    };

    }
}
