using BackendMagic.Data;
using BackendMagic.Model;

namespace BackendMagic.Services.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private SchoolContext dbContext; 

        public HouseRepository(SchoolContext context)
        {
            dbContext = context;
        }

        public House GetHouseById(int id)
        {
            return dbContext.Houses.First(h => h.HouseId == id);
        }

        public IEnumerable<House> GetHouses()
        {
            return dbContext.Houses.ToList();   
        }

        public void UpdateHouse(House house)
        {
           dbContext.Houses.Update(house);
           dbContext.SaveChanges();
        }
    }
}
