using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TaskItem>()
    .HasOne(t => t.User)
    .WithMany(u => u.TaskItems)
    .HasForeignKey(t => t.UserId)
    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
