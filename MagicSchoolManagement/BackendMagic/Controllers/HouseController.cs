using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Services.Interfaces;
using BackendMagic.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using BackendMagic.DTOs;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;

namespace BackendMagic.Controllers 
// Handles HTTP requests and responses, delegating all business logic to the service layer.
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHouseService _houseService; // Only interact with service
        private readonly ITeacherService _teacherService;
       
       

        public HouseController(ILogger<HouseController> logger, IConfiguration configuration, IHouseService houseService, ITeacherService teacherService)
        {
            _logger = logger;   
            _configuration = configuration;
            _houseService = houseService;
            _teacherService = teacherService;
           
           
        }
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult<List<House>>> GetAllFourHouses()
        {
            
            try
            {
                
                var houses = await _houseService.GetAllHouses();
                if (houses == null || houses.Count == 0)
                {
                    return NotFound("No houses were found.");
                }
                var houseDtos = new List<HouseDto>();

                // Map each House to HouseDto
                foreach (var house in houses)
                {
                    var houseDto = new HouseDto
                    {
                        HouseId = house.HouseId,
                        HouseName = house.HouseName.ToString(), 
                        Points = house.Points,
                        TeacherId = house.TeacherId,
                        Students = house.Students,
                        Rooms = house.Rooms
                    };

                    // Add the DTO to the list
                    houseDtos.Add(houseDto);
                }

                // Return the list of DTOs
                return Ok(houseDtos);



       
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching houses");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{houseId}")]
        public async Task<ActionResult<House>> GetHouseById(int houseId)
        {
            var house = await _houseService.GetHouseById(houseId);
            if (house == null)
            {
                return NotFound("No house found.");
            }

            var headmaster = await _teacherService.GetTeacherById(house.TeacherId);
            if (headmaster == null)
            {
                return NotFound("No headmaster found.");
            }

            var houseDto = new HouseDto
            {
                
                
                HouseId = house.HouseId,
                HouseName = house.HouseName.ToString(), // Convert enum to string
                Points = house.Points,
                Headmaster = headmaster.LastName,
                Students = house.Students,
                Rooms = house.Rooms
            };
            return Ok(houseDto);
        }

        [HttpPatch("updatePoints/{houseId}")]
        [Authorize(Roles =("Teacher, Headmaster, Director, Ministry"))]
        public async Task<ActionResult<House>> UpdatePoints(int houseId, [FromBody] UpdateHousePointsReq updateHousePointsReq)
        {
            
            try
            {
                
                var house = await _houseService.UpdatePoints(houseId, updateHousePointsReq.Points, updateHousePointsReq.IsAdd);

                return Ok(house);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("updateHeadmaster/{houseId}")]
        public async Task<ActionResult<House>> UpdateHeadmaster(int houseId, int teacherId)
        {
            try
            {
                var house = await _houseService.UpdateHouseAddHeadMasterByHouseId(houseId, teacherId);

                return Ok(house);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // update a house by id (add or change headmaster)

        // update a house by id(add student) / remove student



    }
      


    
}
