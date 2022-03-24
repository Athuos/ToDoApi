using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Tags")]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TagController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tag>> Get(int id)
        {
            var tag = await context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            return tag;
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> Post(Tag tag)
        {
            
            context.Add(tag);
            await context.SaveChangesAsync();

            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Tag tag, int id)
        {
            if (tag.Id != id)
            {
                return BadRequest("El id de la etiqueta no coincide con la URL.");
            }

            var ex = await context.Tags.AnyAsync(u => u.Id == id);
            if (!ex)
            {
                return NotFound();
            }

            context.Update(tag);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ex = await context.Tags.AnyAsync(t => t.Id == id);
            if (!ex)
            {
                return NotFound();
            }

            context.Remove(new Entities.Tag { Id = id });
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
