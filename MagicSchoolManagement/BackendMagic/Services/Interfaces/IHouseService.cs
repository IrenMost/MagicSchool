using BackendMagic.Model;
using System.Threading.Tasks;

namespace BackendMagic.Services.Interfaces
{
    public interface IHouseService
    {
        Task<List<House>> GetAllHouses();
        Task<House> GetHouseById(int houseId);
        Task<House> UpdateHouse(House house);
        Task<House> UpdatePoints(int houseId, uint points, bool isAdd);
        Task<House> UpdateStudentListByHouseId(int houseid, int studentId);
        Task<House> UpdateHouseAddHeadMasterByHouseId(int houseId, int teacherId);
    }
}
