using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await context.Users.Include(us => us.Tasks).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            context.Add(user);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(User user, int id) 
        {
            if (user.Id != id)
            {
                return BadRequest("El id del usuario no coincide con la URL.");
            }

            var ex = await context.Users.AnyAsync(u => u.Id == id);
            if (!ex)
            {
                return NotFound();
            }

            context.Update(user);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var ex = await context.Users.AnyAsync(u => u.Id == id);
            if (!ex)
            {
                return NotFound();
            }

            context.Remove(new User { Id = id });
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
