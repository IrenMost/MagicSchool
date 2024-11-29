using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackendMagic.Repository
{
    public class HouseElfRepository : IHouseElfRepository
    {
        private readonly SchoolContext _dbContext;
       

        public HouseElfRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task AddAsync(HouseElf houseElft)
        {
            await _dbContext.AddAsync(houseElft);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<HouseElf>> GetAllHouseElves()
        {
            return await _dbContext.HousesElves.ToListAsync();
        }

        public async Task<HouseElf> GetHouseElfById(int houseElfId)
        {
            return await _dbContext.HousesElves.FirstOrDefaultAsync(h => h.HouseElfId == houseElfId);
        }

        public async Task<HouseElf> GetHouseElfByIdentityUserId(string identityUserId)
        {
            return await _dbContext.HousesElves.FirstOrDefaultAsync(h => h.IdentityUserId == identityUserId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateHouseElf(HouseElf houseElf)
        {
            _dbContext.HousesElves.Update(houseElf);
            await _dbContext.SaveChangesAsync();
        }
    }

        
    
}
