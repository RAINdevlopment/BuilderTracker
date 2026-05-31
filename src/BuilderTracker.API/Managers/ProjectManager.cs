using BuilderTracker.API.Models;
using BuilderTracker.API.ResourceAccess;
using BuilderTracker.API.ResourceAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuilderTracker.API.Managers;

public interface IProjectManager
{
    Task<List<ProjectDto>> GetAllAsync();
    Task<ProjectDto?> GetByIdAsync(int id);
    Task<ProjectDto> CreateAsync(CreateProjectRequest request);
}

public class ProjectManager : IProjectManager
{
    private readonly AppDbContext _db;

    public ProjectManager(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        return await _db.Projects
            .Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.CreatedAt))
            .ToListAsync();
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var p = await _db.Projects.FindAsync(id);
        return p is null ? null : new ProjectDto(p.Id, p.Name, p.Description, p.CreatedAt);
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectRequest request)
    {
        var project = new Project { Name = request.Name, Description = request.Description };
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
        return new ProjectDto(project.Id, project.Name, project.Description, project.CreatedAt);
    }
}
