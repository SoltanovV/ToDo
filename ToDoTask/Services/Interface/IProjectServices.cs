namespace AspBackend.Services.Interface;

public interface IProjectServices
{
    public Task<Project> CreateProjectAsync(Project model);
    public Task<Project> UpdateProjectAsync(Project model);
    public Task<Project> DeleteProjectAsync(int id);

    public Task<UserProject> AddUserProjectAsync(UserProject model);
    public Task<UserProject> DeleteUserProjectAsync(UserProject model);
}
