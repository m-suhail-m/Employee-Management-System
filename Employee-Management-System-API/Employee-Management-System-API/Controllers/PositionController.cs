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
                PositionDescription = positionVM.PositionDescription,
                HasDepartment = true,
                HasReportingLineManager = true
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

        [HttpGet]
        [Route("SearchPositionById/{id}")]
        public async Task<IActionResult> SearchPositionById(int id)
        {
            Position position = await _repository.GetPositionById(id);
            if (position == null) return NotFound();
            return Ok(position);
        }

        [HttpGet("SearchPositionsByQuery/{query}")]
        public async Task<IActionResult> SearchPositionsByQuery(string query)
        {
            Position[] positions = await _repository.GetPositionByName(query);
            return Ok(positions);
        }

        [HttpPut]
        [Route("UpdatePosition/{id}")]
        public async Task<IActionResult> UpdatePosition(int id, PositionVM positionVm)
        {
            Position currentPosition = await _repository.GetPositionById(id);
            if (currentPosition == null) return NotFound();

            currentPosition.PositionName = positionVm.PositionName;
            currentPosition.PositionDescription = positionVm.PositionDescription;

            try
            {
                if (! await _repository.SaveAllChangesAsync())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            return NoContent();
        }

        [HttpDelete("DeletePosition/{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            Position position = await _repository.GetPositionById(id);
            if (position == null) return NotFound();
            if (position.PositionId == 1 || position.PositionId == 2 || position.PositionId == 3 || position.PositionId == 4) return Forbid();
            

            try
            {
                _repository.Delete(position);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            if (await _repository.SaveAllChangesAsync())
            {
                return NoContent();
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
