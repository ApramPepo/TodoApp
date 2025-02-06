using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<TodoItem> Todos { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}