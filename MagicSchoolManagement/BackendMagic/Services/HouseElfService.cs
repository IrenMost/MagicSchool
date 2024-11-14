using BackendMagic.Model;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Services
{
    public class HouseElfService : IHouseElfService
    {
        private readonly IHouseElfRepository _houseElfRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public HouseElfService(IHouseElfRepository houseElfRepository, UserManager<IdentityUser> userManager)
        {
            _houseElfRepository = houseElfRepository;
            _userManager = userManager;
        }

        public  async Task<List<HouseElf>> GetAllouseElves()
        {
            return await _houseElfRepository.GetAllHouseElves();
        }

        public async Task<HouseElf> GetouseElfById(int houseElfId)
        {
            return await _houseElfRepository.GetHouseElfById(houseElfId);
        }

        public async Task<HouseElf> GetouseElfByIdentityUserId(string identityUserId)
        {
            return await _houseElfRepository.GetHouseElfByIdentityUserId(identityUserId);
        }

        public async Task<HouseElf> UpdateHouseElf(HouseElf houseElf)
        {
            await _houseElfRepository.UpdateHouseElf(houseElf);
            return houseElf;
        }
    }
}
