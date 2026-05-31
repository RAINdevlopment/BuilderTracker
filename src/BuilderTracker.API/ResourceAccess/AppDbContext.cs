using BuilderTracker.API.ResourceAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuilderTracker.API.ResourceAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectTask> Tasks => Set<ProjectTask>();
}
