namespace BuilderTracker.API.Models;

public record ProjectDto(int Id, string Name, string Description, DateTime CreatedAt);

public record CreateProjectRequest(string Name, string Description);

public record TaskDto(int Id, string Title, bool IsComplete, int ProjectId);

public record CreateTaskRequest(string Title, int ProjectId);
