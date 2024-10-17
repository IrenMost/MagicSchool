using BackendMagic.Model;

namespace BackendMagic.Repository.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<House>> GetHouses();                         
        Task<House> GetHouseById(int houseId);       

        Task AddAsync(House house);
        Task UpdateHouse(House house);

        Task SaveChangesAsync();
        //Task UpdateHousePointByHouseId(int houseId, uint points, bool isAdd);  
        //Task UpdateHouseAddHeadMasterByHouseId(int houseId, int teacherId);    
        //Task UpdateStudentListByHouseId(int houseId, int studentId);

    }
}
