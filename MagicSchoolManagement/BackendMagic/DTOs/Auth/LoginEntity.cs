namespace BackendMagic.DTOs.Auth
{
    public class LoginEntity
    {
        public string UserType { get; set; }
        public object User { get; set; }

        public LoginEntity(string userType, object user)
        {
            UserType = userType;
            User = user;
        }
    }
}
