using BackendMagic.Model.Enums;

namespace BackendMagic.Model
{
    public class Grade
    {
        public int HouseId { get; set; }
        public GradeType GradeType { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
