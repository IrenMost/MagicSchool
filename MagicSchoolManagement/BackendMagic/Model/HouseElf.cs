using BackendMagic.Model.Enums;

namespace BackendMagic.Model
{
    public class HouseElf
    {
        public int HouseElfId { get; set; }
        public string Name { get; set; }
        public House HouseToWorkFor { get; set; }
        
        
    }

}
