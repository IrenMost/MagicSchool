namespace BackendMagic.Data.SeedingDto
{
    public class TeacherData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Model.Enums.Gender Gender { get; set; }
        public Model.Enums.Level Level { get; set; }
        public Model.Enums.Course Course { get; set; }
        public string Role { get; set; }
    }
}
