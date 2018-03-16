using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestOpen.Models;
using System.Collections.Generic;

namespace TestOpen.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ApiContext _context;

        public UsersController(ApiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            var users = await _context.Users
                .Include(u => u.Posts)
                .ToArrayAsync();

            var response = users.Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                posts = u.Posts.Content
            });

            return Ok(response);

        }
        //[HttpGet]
        //public IEnumerable<User> GetAll()
        //{
        //    return _context.Users.ToList();
        //}

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.Users.Include(u => u.Posts).FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                Console.WriteLine(item);
                return BadRequest();
            }

            _context.Users.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.Users.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Id = item.Id;
            todo.FirstName = item.FirstName;
            todo.LastName = item.LastName;
            todo.Posts = item.Posts;

            _context.Users.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Users.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Users.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
