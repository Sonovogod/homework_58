using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Enums;

namespace ToDoList.Models;

public class TaskContext : IdentityDbContext<User>
{
    public DbSet<Task> Tasks { get; set; }
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>().HasQueryFilter(task => task.State != TaskStates.Deleted);
        base.OnModelCreating(modelBuilder);
    }
}