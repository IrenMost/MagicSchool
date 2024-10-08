using BackendMagic.Model.Enums;

namespace BackendMagic.Model
{
    public class House
    {
        public int HouseId { get; set; }
        public HouseName HouseName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher HeadMaster { get; set; } 
        public uint Points { get; set; }

        public void getOrLoosePoints(uint point, bool isAdd)
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
