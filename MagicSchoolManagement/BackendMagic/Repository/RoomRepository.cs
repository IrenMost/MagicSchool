using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendMagic.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SchoolContext _dbContext;

        public RoomRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRoomAsync(Room room)
        {
           await _dbContext.Rooms.AddAsync(room);
            await SaveChangesAsync();

        }

        public async Task<Room> GetRoomById(int roomId)
        {
           return await _dbContext.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);
         
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _dbContext.Rooms.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
        }
    }
}
