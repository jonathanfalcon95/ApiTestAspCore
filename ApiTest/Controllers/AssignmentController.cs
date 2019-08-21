using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Models;
using ApiTest.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [Route("api/assignment")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly Repository _repository;
        public AssignmentController(BaseContext context, Repository repository)
        {
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));


        }

        // GET: api/user/id/assignment

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAll()
        {

            return await _context.Assignments.ToListAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment([FromRoute] long id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignments.Where(x => x.UserID == id).ToListAsync();

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetHardwareByUserID([FromRoute] long id)
        {

            var response = await _repository.GetById(id);
            if (response == null) { return NotFound(); }
           

            return Ok(response);
        }

        // POST: api/Assignments
        [HttpPost]
        public async Task<IActionResult> PostAssignment([FromBody] Assignment assignment)
        {
            assignment.Software = null;
            assignment.Hardware = null;
            assignment.User = null;

           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
             _context.Assignments.Add(assignment);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssignment), new { id = assignment.UserID }, assignment);
        }


       

        // DELETE: api/User/1
        [HttpPost("delete")]
        public async Task DeleteAss([FromBody] Assignment assignment)
        {
            Console.WriteLine(assignment);
            assignment.Software = null;
            assignment.Hardware = null;
            assignment.User = null;

            await _repository.DeleteById(assignment);
            
        }
    }
}