using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [Route("api/user/{userID}/assignment")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly BaseContext _context;

        public AssignmentController(BaseContext context)
        {
            _context = context;

            
        }

        // GET: api/user/id/assignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAll(int userID)
        {

            return await _context.Assignment.Where(x => x.UserID == userID).ToListAsync();
            
        }

        //// GET: api/users/1
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(long id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}


        //// POST: api/users
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Users.Add(user);
        //        await _context.SaveChangesAsync();
        //        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //    }

        //    return BadRequest(ModelState);
        //}

        //// PUT: api/user/2
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(long id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        //// DELETE: api/User/1
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(long id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}