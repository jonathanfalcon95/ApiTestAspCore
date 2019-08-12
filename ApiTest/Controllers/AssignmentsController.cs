using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Models;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly BaseContext _context;

        public AssignmentsController(BaseContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public IEnumerable<Assignment> GetAssignment()
        {
            return _context.Assignment;
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment([FromRoute] long id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignment.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/Assignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment([FromRoute] long id, [FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.HardwareID)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assignments
        [HttpPost]
        public async Task<IActionResult> PostAssignment([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Assignment.Add(assignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssignmentExists(assignment.HardwareID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssignment", new { id = assignment.HardwareID }, assignment);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignment.Remove(assignment);
            await _context.SaveChangesAsync();

            return Ok(assignment);
        }

        private bool AssignmentExists(long id)
        {
            return _context.Assignment.Any(e => e.HardwareID == id);
        }
    }
}