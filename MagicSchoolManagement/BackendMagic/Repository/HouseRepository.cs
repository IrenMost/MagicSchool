using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace BackendMagic.Repository
{
 // Handles all data access operations (CRUD), interacting with the database.
    public class HouseRepository : IHouseRepository
    {
        private readonly SchoolContext _dbContext;

        public HouseRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(House house)
        {
            await _dbContext.AddAsync(house);
        }

        public async Task<House> GetHouseById(int houseId)
        {
            return await _dbContext.Houses.FirstOrDefaultAsync(h => h.HouseId == houseId);
        }

        public async Task<List<House>> GetHouses()
        {
            return await _dbContext.Houses.ToListAsync();
        }

        public async Task UpdateHouse(House house)
        {
            _dbContext.Houses.Update(house);
            await _dbContext.SaveChangesAsync();
        }


        
        // TODO
        public async Task UpdateHouseAddHeadMasterByHouseId(int houseId, int teacherId)
        {
            var teacher = dbContext.Teachers.First(t => t.TeacherId == teacherId);
            var house = dbContext.Houses.FirstOrDefault(h => h.HouseId == houseId);
            if (teacher == null)
            {
                throw new KeyNotFoundException("no such teacher ");
            }
            if (house == null)
            {
                throw new KeyNotFoundException("no such house ");
            }
            else
            {
                house.HeadMaster = teacher;
                dbContext.SaveChanges();
            }

        }

        public async Task UpdateHousePointByHouseId(int houseId, uint points, bool isAdd)
        {
            var house = dbContext.Houses.FirstOrDefault(h => h.HouseId == houseId);
            if (house == null)
            {
                throw new KeyNotFoundException("no such house ");
            }
            else
            {
                house.GetOrLoosePoints(points, isAdd);
                dbContext.SaveChanges();
            }

        }

        public async Task UpdateStudentListByHouseId(int houseId, int studentId)
        {
            var house = dbContext.Houses.FirstOrDefault(h => h.HouseId == houseId);
            var student = dbContext.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (house == null)
            {
                throw new KeyNotFoundException("no such house ");
            }
            if (student == null)
            {
                throw new KeyNotFoundException("no such studnet ");
            }
            else
            {
                house.AddStudentToAHouse(student);
                dbContext.SaveChanges();
            }

        }
    }
}
