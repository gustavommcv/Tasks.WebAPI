using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<UserTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTask>().HasData(new UserTask { Id = Guid.NewGuid(), Title = "Finish this API", Description = "Just three stories", status = "Pending" });
        }
    }
}
