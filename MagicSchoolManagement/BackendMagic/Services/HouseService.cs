using BackendMagic.Model;
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

            public HouseService(IHouseRepository houseRepository)
            {
                _houseRepository = houseRepository;
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

        public Task<House> UpdateHouseAddHeadMasterByHouseId(int houseId, int teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<House> UpdatePoints(int houseId, uint points, bool isAdd)
        {
            var house = await _houseRepository.GetHouseById(houseId);
            if (house != null)
            {
                house.GetOrLoosePoints(points, isAdd);
                await _houseRepository.UpdateHouse(house);
            }
            return house;
        }

        public Task<House> UpdateStudentListByHouseId(int houseid, int studentId)
        {
            throw new NotImplementedException();
        }
    }
    
}

