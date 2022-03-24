using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TaskController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // get para todas las tareas
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Entities.Task>> Get(int id) 
        {
            var task = await context.Tasks.Include(t => t.UserId).FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }
        // get para tareas por usuario
        [HttpGet("{id_user:int}")]
        //public async Task<ActionResult<Entities.Task>> GetWU(int id_user) 
        //{ 
        //    var task = await context.Taks.
        //}

        [HttpPost]
        public async Task<ActionResult<Entities.Task>> Post(Entities.Task task) 
        {
            var existeUser = await context.Users.AnyAsync(u => u.Id == task.UserId);
            if (!existeUser)
            {
                return BadRequest($"No existe el usuario de Id:{task.UserId}.");
            }

            context.Add(task);
            await context.SaveChangesAsync();

            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Entities.Task task, int id)
        {
            if (task.Id != id)
            {
                return BadRequest("El id de la tarea no coincide con la URL.");
            }

            var ex = await context.Tasks.AnyAsync(u => u.Id == id);
            if (!ex)
            {
                return NotFound();
            }

            context.Update(task);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ex = await context.Tasks.AnyAsync(u => u.Id == id);
            if (!ex)
            {
                return NotFound();
            }

            context.Remove(new Entities.Task { Id = id });
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
