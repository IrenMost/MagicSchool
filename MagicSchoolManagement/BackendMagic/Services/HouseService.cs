using BackendMagic.Model;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;

namespace BackendMagic.Services
{
    // Contains the business logic.
    // It fetches data from the repository and processes it according to the business rules
    // before returning it to the controller.
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;


        public HouseService(IHouseRepository houseRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _houseRepository = houseRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<House>> GetAllHouses()
        {
            return await _houseRepository.GetHouses();
        }

        public async Task<House> GetHouseById(int houseId)
        {
            return await _houseRepository.GetHouseById(houseId);
        }

        public async Task<House> UpdateHouse(House house)
        {
            await _houseRepository.UpdateHouse(house);
            return house;
        }

        public async Task<House> UpdateHouseAddHeadMasterByHouseId(int houseId, int teacherId)
        {
            var house = await _houseRepository.GetHouseById(houseId);
            var teacher = await _teacherRepository.GetTeacherById(teacherId);
            if (teacher == null)
            {
                throw new KeyNotFoundException("no such teacher ");
            }
            if (house == null)
            {
                throw new KeyNotFoundException("no such house ");
            }

            house.HeadMaster = teacher;
            teacher.Level = (Model.Enums.Level)1; // to make the teacher's level headmaster
            await _houseRepository.UpdateHouse(house);
            await _teacherRepository.UpdateTeacher(teacher);
            return house;
        }

        public async Task<House> UpdatePoints(int houseId, uint points, bool isAdd)
        {
            var house = await _houseRepository.GetHouseById(houseId);
            if (house != null)
            {

                if (points < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(points));
                }
                if (isAdd)
                {
                    house.Points += points;
                }
                else if (points > house.Points)
                {
                    house.Points = 0;
                }
                else
                {
                    house.Points -= points;
                }
                await _houseRepository.UpdateHouse(house);
               
            }
            return house;

        }

        public async Task<House> UpdateStudentListByHouseId(int houseId, int studentId)
        {
            var house = await _houseRepository.GetHouseById(houseId);
            var student = await _studentRepository.GetStudentById(studentId);

            if (house == null)
            {
                throw new KeyNotFoundException("no such house ");
            }
            if (student == null)
            {
                throw new KeyNotFoundException("no such studnet ");
            }

            if(house.Students.Count == 0)
            {
                house.Students = new List<Student>();
            }
            house.Students.Add(student);
            await _houseRepository.UpdateHouse(house);
            return house;
        }
    }

}





