using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BaseContext _context;

        public UserController(BaseContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                // Create a new user if collection is empty,
                // which means you can't delete all users.
                 DateTime aDate = DateTime.Now;
                _context.Users.Add(new User { Name = "Juan", UserName = "JPerez", LastName = "Perez", Age = 25, LastSessionDateTime=aDate });
                _context.Users.Add(new User { Name = "Maria", UserName = "MHernandez", LastName = "Hernadez", Age = 21, LastSessionDateTime = aDate });

                _context.SaveChanges();
            }
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                  _context.Users.Add(user);
                 await _context.SaveChangesAsync();
                 return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/user/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/User/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
