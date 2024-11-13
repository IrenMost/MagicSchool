using BackendMagic.Model;

namespace BackendMagic.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRooms();
        Task<Room> GetRoomById(int roomId);

        Task AddRoomAsync (Room room);
        Task UpdateRoom (Room room);

        Task SaveChangesAsync();
    }
}
