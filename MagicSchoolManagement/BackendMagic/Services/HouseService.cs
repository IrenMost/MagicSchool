using BackendMagic.Model;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITeacherService _teacherService;


        public HouseService(IHouseRepository houseRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository, UserManager<IdentityUser> userManager, ITeacherService teacherService)
        {
            _houseRepository = houseRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _userManager = userManager;
            _teacherService = teacherService;
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
            
            var newTeacher = await _teacherRepository.GetTeacherById(teacherId);
            var formerTeacher = await _teacherRepository.GetTeacherById(house.TeacherId);

            var newTeacherUser = await _userManager.FindByIdAsync(newTeacher.IdentityUserId);
            var formerTeacherUser = await _userManager.FindByIdAsync(formerTeacher.IdentityUserId);

           
            if (newTeacherUser == null)
            {
                throw new KeyNotFoundException("No user found for the new teacher");
            }
            if (formerTeacherUser == null)
            {
                throw new KeyNotFoundException("No user found for the former teacher");
            }

            if (newTeacher == null)    
            {
                throw new KeyNotFoundException("no such teacher ");
            }
            if (house == null)
            {
                throw new KeyNotFoundException("no such house ");
            }

            if (formerTeacher != null)
            {
                // Downgrade former headmaster 

                await _teacherService.RemoveRoleFromATeacherByIdentityUserId(formerTeacher.IdentityUserId, "Headmaster");
                

            }
            // updgrade newTeacher
            
            if(newTeacher != null)
            {
                await _teacherService.UpdateByAddingRoleToATeacherByIdentityUserId(newTeacher.IdentityUserId, "Headmaster");
                house.HeadMaster = newTeacher;

            }


            await _houseRepository.UpdateHouse(house);
            
           
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
            student.HouseId = houseId;
            student.House = house;
            await _studentRepository.UpdateStudent(student);
            return house;
        }
    }

}





