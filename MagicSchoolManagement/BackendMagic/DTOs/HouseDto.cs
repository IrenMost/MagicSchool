using BackendMagic.Model;

namespace BackendMagic.DTOs
{
    public class HouseDto
    {
        public int HouseId { get; set; }
        public string HouseName { get; set; } // Store the name as string 
        public uint Points { get; set; }
        public int TeacherId { get; set; }
        public List<Student> Students { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
