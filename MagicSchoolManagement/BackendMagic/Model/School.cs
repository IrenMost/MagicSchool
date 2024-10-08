namespace BackendMagic.Model
{
    public class School
    {
        string Name { get;  }
        public List<Student> Students { get; set; } 
        public List<Teacher> Teachers { get; set; } 
        public List<Room> Rooms { get; set; } 
        public List<HouseElf> houseElves { get; set; } 

        public School()
        {
            Name = "Hogwarts";
            Students = new List<Student>();
            Rooms = new List<Room>();
            Teachers = new List<Teacher>();
            houseElves = new List<HouseElf>();
        }
    }
}
