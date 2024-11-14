using BackendMagic.Model.Enums;
using BackendMagic.Model;
using System.Threading.Tasks;

namespace BackendMagic.Services.Interfaces
{
    public interface IHouseElfService
    {
        Task<List<HouseElf>> GetAllouseElves();
        Task<HouseElf> GetouseElfById(int houseElfId);

        Task<HouseElf> GetouseElfByIdentityUserId(string identityUserId);
        Task<HouseElf> UpdateHouseElf(HouseElf houseElf);
        
    }
}
