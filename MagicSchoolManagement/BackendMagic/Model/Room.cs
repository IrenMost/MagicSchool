using System.Numerics;

namespace BackendMagic.Model
{
    public class Room
    {
        public int RoomId { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public int MaxCapacity { get; } = 3;

        public bool IsFull {
            get
            {
                return Students.Count >= MaxCapacity;
            }
        }

        // Navigation properties
        public int HouseId { get; set; }
        public virtual House House { get; set; }

    }
}
