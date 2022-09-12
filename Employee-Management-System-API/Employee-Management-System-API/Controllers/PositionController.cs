using Employee_Management_System_API.Models;
using Employee_Management_System_API.Models.Entities;
using Employee_Management_System_API.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IRepository _repository;

        public PositionController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllPositions")]
        public async Task<IActionResult> GetAllPositions()
        {
            try
            {
                Position[] positions = await _repository.GetAllPositionsAsync();
                return Ok(positions);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
           
        }

        [HttpPost]
        [Route("AddPosition")]
        public async Task<IActionResult> AddPosition(PositionVM positionVM)
        {
            Position newPosition = new Position
            {
                PositionName = positionVM.PositionName,
                PositionDescription = positionVM.PositionDescription
            };

            try
            {
                _repository.Add(newPosition);
                if(await _repository.SaveAllChangesAsync())
                {
                    return NoContent();
                }

                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
