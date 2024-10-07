using BackendMagic.Model.Enums;

namespace BackendMagic.Model
{
    public class House
    {
        public int HouseId { get; set; }
        public HouseName HouseName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher HeadMaster { get; set; }
        public int PointsOfHouse { get; set; }
    }
}
