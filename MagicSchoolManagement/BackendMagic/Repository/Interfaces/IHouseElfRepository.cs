using BackendMagic.Model;

namespace BackendMagic.Repository.Interfaces
{
    public interface IHouseElfRepository
    {
        Task<List<HouseElf>> GetAllHouseElves();
        Task<HouseElf> GetHouseElfById(int houseElfId);

        Task<HouseElf> GetHouseElfByIdentityUserId(string identityUserId);
        Task AddAsync(HouseElf houseElft);
        Task UpdateHouseElf(HouseElf houseElf);

        Task SaveChangesAsync();
    }
}
