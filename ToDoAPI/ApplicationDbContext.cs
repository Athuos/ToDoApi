using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Entities.Task> Tasks { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
