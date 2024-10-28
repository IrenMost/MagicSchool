using BackendMagic.Model.Enums;
using System.Numerics;

namespace BackendMagic.Model
{
    public class House
    {
        public int HouseId { get; set; }
        public HouseName HouseName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        
        public uint Points { get; set; } = 10;
        // navigációhoz
        public int TeacherId {  get; set; }
        public Teacher HeadMaster { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();



        public House( HouseName houseName, uint points, int teacherId) {
           
            HouseName = houseName;
            Points = points;
            TeacherId = teacherId;
        }


       


    }
}
