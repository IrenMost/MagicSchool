using BackendMagic.Model.Enums;
using System.Numerics;

namespace BackendMagic.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Pet Pet { get; set; }
       
       

        public List<Course> MyCourses { get; set; } = new List<Course>();
       

        // Navigation properties
        public int HouseId { get; set; }
        public virtual House House { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }


        public int GradeId { get; set; }    
        public virtual Grade Grade { get; set; }

        
    }
}
