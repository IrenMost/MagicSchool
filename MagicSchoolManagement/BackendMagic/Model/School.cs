namespace BackendMagic.Model
{
    public class School
    {
       public int SchoolId { get; set; }
        public string  Name { get; set;  }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<HouseElf> HouseElves { get; set; } = new List<HouseElf>();

        public List<House> Houses { get; set; } = new List<House>();

       
    }
}
