using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;

namespace BackendMagic.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var houseRepository = serviceProvider.GetService<IHouseRepository>();
            var teacherRepository = serviceProvider.GetService<ITeacherRepository>();

            var houses = await houseRepository.GetHouses();

            if (houses.Count() == 0)
            {
                var house1 = new House(1, Model.Enums.HouseName.Gryffindor, 15);
                var house2 = new House(1, Model.Enums.HouseName.Hufflepuff, 15);
                var house3= new House(1, Model.Enums.HouseName.Ravenclaw, 15);
                var house4 = new House(1, Model.Enums.HouseName.Slytherin, 15);

                await houseRepository.AddAsync(house1);
                await houseRepository.AddAsync(house2);
                await houseRepository.AddAsync(house3);
                await houseRepository.AddAsync(house4);

            }

            var teachers = await teacherRepository.GetAllTeachers();
          
        }
    }
}
