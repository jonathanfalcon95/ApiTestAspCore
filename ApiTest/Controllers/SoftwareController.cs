using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [Route("api/software")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly BaseContext _context;

        public SoftwareController(BaseContext context)
        {
            _context = context;

            if (_context.Software.Count() == 0)
            {
                // Create a new software if collection is empty,
                // which means you can't delete all softwares.

                _context.Software.Add(new Software { SoftwareName = "Windows" });


                _context.SaveChanges();
            }
        }

        // GET: api/softwares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Software>>> GetSoftware()
        {
            return await _context.Software.ToListAsync();
        }

        // GET: api/softwares/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Software>> GetSoftware(long id)
        {
            var software = await _context.Software.FindAsync(id);

            if (software == null)
            {
                return NotFound();
            }

            return software;
        }


        // POST: api/softwares
        [HttpPost]
        public async Task<ActionResult<Software>> PostSoftware(Software software)
        {
            if (ModelState.IsValid)
            {
                _context.Software.Add(software);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSoftware), new { id = software.Id }, software);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/software/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftware(long id, Software software)
        {
            if (id != software.Id)
            {
                return BadRequest();
            }

            _context.Entry(software).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/software/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftware(long id)
        {
            var software = await _context.Software.FindAsync(id);

            if (software == null)
            {
                return NotFound();
            }

            _context.Software.Remove(software);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}