namespace BackendMagic.Model
{
    public class TeacherGrade
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
