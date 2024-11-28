using BackendMagic.Model;

namespace BackendMagic.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(int roomId);
        Task<List<Room>> GetRoomByHouseId(int houseId);
        Task CreateNewRoom(Room room);
        Task<Room> UpdateRoomById(Room room, int roomId);
        Task<Room> AddStudentToRoomByIdUpdate(int roomId, int studentId);
        Task<Room> RemoveStudentToRoomByIdUpdate(int roomId, int studentId);
        Task<Room> DeleteRoomById(int roomId);
    }
}
