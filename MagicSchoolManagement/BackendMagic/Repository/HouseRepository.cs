using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace BackendMagic.Repository
{
 // Handles all data access operations (CRUD), interacting with the database.
    public class HouseRepository : IHouseRepository
    {
        private readonly SchoolContext _dbContext;
       

        public HouseRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task AddAsync(House house)
        {
            await _dbContext.Houses.AddAsync(house);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<House> GetHouseById(int houseId)
        {
            return await _dbContext.Houses.FirstOrDefaultAsync(h => h.HouseId == houseId);
        }

        public async Task<List<House>> GetHouses()
        {
            return await _dbContext.Houses.ToListAsync();
        }

        public async Task UpdateHouse(House house)
        {
            _dbContext.Houses.Update(house);
            await _dbContext.SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


    }
}
