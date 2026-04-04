using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDestinationAPI.Data;
using TravelDestinationAPI.DTOs;
using TravelDestinationAPI.Models;
using TravelDestinationAPI.Services;

namespace TravelDestinationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        // GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {            
            var data =  await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/Destinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            return Ok(destination);
        }

        // PUT: api/Destinations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, UpdateDestinationDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(dto);
            return NoContent();
        }

        // POST: api/Destinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(CreateDestinationDto destination)
        {
            var data = await _service.AddAsync(destination);
            return CreatedAtAction("GetDestination", new { destination });
        }

        // DELETE: api/Destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
   
    }
}
