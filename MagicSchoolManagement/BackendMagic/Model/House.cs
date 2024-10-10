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



        public House(int houseId, HouseName houseName, uint points) {
            HouseId = houseId;
            HouseName = houseName;
            Points = points;
        }
        // to get all the properties
        public void ChangeHeadMaster(Teacher teacher)
        {
           
            this.HeadMaster = teacher;
        }

        public void AddStudentToAHouse(Student student) {
            this.Students.Add(student);

        }
   
        public void GetOrLoosePoints(uint point, bool isAdd)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point));
            }
            if (isAdd)
            {
                this.Points += point;
            }
            else if (point > this.Points) {
                this.Points = 0;
            }
            else
            {
                this.Points -= point;
            }
        }
    }
}
