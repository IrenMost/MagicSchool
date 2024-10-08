using BackendMagic.Model;

namespace BackendMagic.Services.Repository
{
    public interface IHouseRepository
    {
        IEnumerable<House> GetHouses();
        House GetHouseById(int id);
        void UpdateHouse(House house);
        
    }
}
