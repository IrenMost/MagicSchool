using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Services.Interfaces;
using BackendMagic.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace BackendMagic.Controllers 
// Handles HTTP requests and responses, delegating all business logic to the service layer.
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHouseService _houseService; // Only interact with service
       
       

        public HouseController(ILogger<HouseController> logger, IConfiguration configuration, IHouseService houseService)
        {
            _logger = logger;   
            _configuration = configuration;
            _houseService = houseService;
           
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<House>>> GetAllFourHouses()
        {
            var houses = await _houseService.GetAllHouses();
            if (houses == null || houses.Count == 0)
            {
                return NotFound("No houses were found.");
            }
            return Ok(houses);
        }

        [HttpGet("{houseId}")]
        public async Task<ActionResult<House>> GetHouseById(int houseId)
        {
            var house = await _houseService.GetHouseById(houseId);
            if (house == null)
            {
                return NotFound("No house found.");
            }
            return Ok(house);
        }

        [HttpPatch("{houseId}/updatePoints")]
        public async Task<ActionResult<House>> UpdatePoints(int houseId, uint points, bool isAdd)
        {
            try
            {
                var house = await _houseService.UpdatePoints(houseId, points, isAdd);
                return Ok(house);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //*****


        //[HttpPatch("/updatePoints/houseId")]

        //public async Task<ActionResult<House>> UpdatePoints(int houseId, uint point, bool IsAdd)
        //{
        //    if (point < 0)
        //    {
        //        return BadRequest("Invalid point value. Points cannot be negative.");
        //    }

        //    var house = await dbContext.Houses.SingleOrDefaultAsync(h => h.HouseId == houseId);

        //    if (house == null)
        //    {
        //        return NotFound("no house found");
        //    }
        //    if (house != null)
        //    {
        //        house.GetOrLoosePoints(point, IsAdd);
        //    }

        //    await dbContext.SaveChangesAsync();
        //    return Ok(house);
        //}

        //TODO 1, 2,

        // update a house by id (add or change headmaster

        // update a house by id(add student) / remove student

       

    }
      


    
}
