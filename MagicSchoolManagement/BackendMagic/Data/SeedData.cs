using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendMagic.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {

          
            var houseRepository = serviceProvider.GetService<IHouseRepository>();
            var teacherRepository = serviceProvider.GetService<ITeacherRepository>();
            if (houseRepository == null)
            {
                throw new InvalidOperationException("IHouseRepository is not registered in the DI container.");
            }
            if (teacherRepository == null)
            {
                throw new InvalidOperationException("IHouseRepository is not registered in the DI container.");
            }


            var teachers = await teacherRepository.GetAllTeachers();

            if (teachers.Count() == 0)
            {
                var teacher1 = new Teacher("Severus", "Snape", Model.Enums.Gender.Male, Model.Enums.Level.Headmaster);
                var teacher2 = new Teacher("Albus", "Dumbledor", Model.Enums.Gender.Male, Model.Enums.Level.Director);
                var teacher3 = new Teacher("Minerva", "McGonagall", Model.Enums.Gender.Female, Model.Enums.Level.Headmaster, Model.Enums.Course.Transfiguration);
                var teacher4 = new Teacher("Pomona", "Sprout", Model.Enums.Gender.Female, Model.Enums.Level.Headmaster, Model.Enums.Course.Herbology);
                var teacher5 = new Teacher("Filius", "Flitwick", Model.Enums.Gender.Male, Model.Enums.Level.Headmaster, Model.Enums.Course.Charms);
                var teacher6 = new Teacher("Rolanda", "Hooch", Model.Enums.Gender.Female, Model.Enums.Level.Teacher, Model.Enums.Course.Flying);
                var teacher7 = new Teacher("Sybill", "Trelawney", Model.Enums.Gender.Female, Model.Enums.Level.Teacher);

                // i have tried it with params
                await teacherRepository.AddAsync(teacher1, teacher2, teacher3, teacher4, teacher5, teacher6, teacher7);


            }

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
    }
}
