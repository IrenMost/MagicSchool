using BackendMagic.Model.Enums;

namespace BackendMagic.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Grade Grade { get; set; } 
        public int PointsOfStudent { get; set; }

        public List<Course> MyCourses { get; set; } = new List<Course>();
       

        // Navigation properties
        public int HouseId { get; set; }
        public House House { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
