using BackendMagic.Model;
using BackendMagic.Repository;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;

namespace BackendMagic.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IStudentRepository _studentRepository;

        public RoomService(IRoomRepository roomRepository, IStudentRepository studentRepository)
        {
            _roomRepository = roomRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Room> AddStudentToRoomByIdUpdate(int roomId, int studentId)
        {
            var room = await _roomRepository.GetRoomById(roomId);
            var student = await _studentRepository.GetStudentById(studentId);
            if (room == null) {
                throw new KeyNotFoundException("No room found");
            }
            if(room.IsFull)
            {
                throw new Exception("the room is full");
            }
            if (room.MaxCapacity > room.Students.Count)
            {
                room.Students.Add(student);
                student.RoomId= roomId;
                
                
            }
                
            await _roomRepository.UpdateRoom(room);
            await _studentRepository.UpdateStudent(student);
            return room;
            
        }

        public async Task CreateNewRoom(Room room)
        {
            await _roomRepository.AddRoomAsync(room);
        }

        public async Task<Room> DeleteRoomById(int roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _roomRepository.GetRooms();
        }

        public async Task<List<Room>> GetRoomByHouseId(int houseId)
        {
            var rooms = await _roomRepository.GetRooms();

            List<Room> houseRooms = new List<Room>();

            foreach (var room in rooms)
            {
                if (room.HouseId == houseId)
                {
                    houseRooms.Add(room);
                }
            }

                return houseRooms;
        }

        public async Task<Room> GetRoomById(int roomId)
        {
            return await _roomRepository.GetRoomById(roomId);
        }

        public async Task<Room> RemoveStudentToRoomByIdUpdate(int roomId, int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> UpdateRoomById(Room room, int roomId)
        {
            throw new NotImplementedException();

        }
    }
}
