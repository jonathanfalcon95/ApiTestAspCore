using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [Route("api/hardware")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
        private readonly BaseContext _context;

        public HardwareController(BaseContext context)
        {
            _context = context;

            if (_context.Hardware.Count() == 0)
            {
                // Create a new hardware if collection is empty,
                // which means you can't delete all hardwares.
              
                _context.Hardware.Add(new Hardware { HardwareName = "Mouse"});
              

                _context.SaveChanges();
            }
        }

        // GET: api/hardware
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hardware>>> GetHardware()
        {
            return await _context.Hardware.ToListAsync();
        }

        // GET: api/hardware/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Hardware>> GetHardware(long id)
        {
            var hardware = await _context.Hardware.FindAsync(id);

            if (hardware == null)
            {
                return NotFound();
            }

            return hardware;
        }


        // POST: api/hardware
        [HttpPost]
        public async Task<ActionResult<Hardware>> PostHardware(Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                _context.Hardware.Add(hardware);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetHardware), new { id = hardware.Id }, hardware);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/hardware/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHardware(long id, Hardware hardware)
        {
            if (id != hardware.Id)
            {
                return BadRequest();
            }

            _context.Entry(hardware).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Hardware/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHardware(long id)
        {
            var hardware = await _context.Hardware.FindAsync(id);

            if (hardware == null)
            {
                return NotFound();
            }

            _context.Hardware.Remove(hardware);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}