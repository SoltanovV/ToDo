namespace AspBackend.Services;

public class ProjectServices: IProjectServices
{
    private ApplicationContext _db;

    public ProjectServices(ApplicationContext db)
    {
        _db = db;
    }
    public async Task<Project> CreateProjectAsync(Project model)
    {
        try
        {
            var creted = await _db.Project.AddAsync(model);

            await _db.SaveChangesAsync();

            var result = await _db.Project.FirstOrDefaultAsync(p => p.Id == creted.Entity.Id);

            return result;
        }
        catch
        {
            throw;
        }
    }
    public async Task<Project> UpdateProjectAsync(Project model)
    {
        try
        {
                var updateProjcet = _db.Project.Update(model);

                await _db.SaveChangesAsync();

                return updateProjcet.Entity;  
        }
        catch
        {
            throw;
        }

    }
    public async Task<Project> DeleteProjectAsync(int id)
    {
        try
        {
            var deleted = await _db.Project.FirstOrDefaultAsync(t => t.Id == id);
            var result = _db.Project.Remove(deleted);

            await _db.SaveChangesAsync();

            return result.Entity;
        }
        catch
        {
            throw;
        }
    }

    public async Task<UserProject> AddUserProjectAsync(UserProject model)
    {
        try
        {
            var result = await _db.UsersProjects.AddAsync(model);
            await _db.SaveChangesAsync();

            return result.Entity;
        }
        catch
        {
            throw;
        }
    }
    public async Task<UserProject> DeleteUserProjectAsync(UserProject model)
    {
        try
        {
            var result = _db.UsersProjects.Remove(model);

            await _db.SaveChangesAsync();

            return result.Entity;
        }
        catch
        {
            throw;
        }
    }
}
