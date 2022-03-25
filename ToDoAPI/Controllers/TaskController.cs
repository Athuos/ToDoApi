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

        [HttpGet]
        public async Task<ActionResult<List<Entities.Task>>> Get([FromQuery] string user = null, [FromQuery] string tag = null, [FromQuery] string finished = null)
        {
            List<Entities.Task> tasks = context.Tasks.ToList();


            if (user != null)
            {
                tasks = (List<Entities.Task>)context.Tasks.Where(t => t.UserId == (Convert.ToInt32(user))).ToList();
            }

            if (tag != null)
            {
                tasks = (List<Entities.Task>)context.Tasks.Where(t => t.TagId == (Convert.ToInt32(tag))).ToList();
            }

            if(finished == "1") 
            {
                tasks = (List<Entities.Task>)context.Tasks.Where(t => t.Status == true).ToList();
            }else if (finished == "0") 
            { 
                tasks = (List<Entities.Task>)context.Tasks.Where(t => t.Status == false).ToList();
            }

            return tasks;
        }

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
