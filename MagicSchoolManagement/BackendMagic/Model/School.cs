namespace BackendMagic.Model
{
    public class School
    {
        public int SchoolId { get; } = 0;
        string Name { get;  }
        public List<Student> Students { get; set; } 
        public List<Teacher> Teachers { get; set; } 
        public List<Room> Rooms { get; set; } 
        public List<HouseElf> HouseElves { get; set; } 

        public List<House> Houses { get; set; }

        public School()
        {
            Name = "Hogwarts";
            Students = new List<Student>();
            Rooms = new List<Room>();
            Teachers = new List<Teacher>();
            HouseElves = new List<HouseElf>();
            Houses = new List<House>();
        }
    }
}
