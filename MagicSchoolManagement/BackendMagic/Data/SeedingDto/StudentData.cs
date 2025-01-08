namespace BackendMagic.Data.SeedingDto
{
    public class StudentData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Model.Enums.Gender Gender { get; set; }
        public Model.Enums.Pet Pet { get; set; }
       public int HouseId { get; set; }   
        public int RoomId { get; set; }
        public int GradeId { get; set; }
        public string Role { get; set; }
    }
}
