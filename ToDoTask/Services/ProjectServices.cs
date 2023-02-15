namespace AspBackend.Services;

public class ProjectServices: IProjectServices
{
    private ApplicationContext _db;

    public ProjectServices(ApplicationContext db)
    {
        _db = db;
    }
    public async Task<Project> CreateProject(Project model)
    {
        try
        {
            var result = await _db.Project.AddAsync(model);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
    public async Task<Project> UpdateProject(Project model)
    {
        try
        {


            var updateProjcet = _db.Project.Update(model);

            await _db.SaveChangesAsync();

            return updateProjcet.Entity;
        }
        catch(Exception ex)
        {
            throw; throw;
        }

    }
    public async Task<Project> DeleteProject(int id)
    {
        try
        {
            var deleted = await _db.Project.FirstOrDefaultAsync(t => t.Id == id);
            var result = _db.Project.Remove(deleted);

            await _db.SaveChangesAsync();

            return result.Entity;
        }
        catch(Exception ex)
        {
            throw;
        }
    }

    public async Task<UserProject> AddUserProject(UserProject model)
    {
        try
        {
            var result = await _db.UsersProjects.AddAsync(model);
            await _db.SaveChangesAsync();

            return result.Entity;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<UserProject> DeleteUserProject(UserProject model)
    {
        try
        {
            var result = _db.UsersProjects.Remove(model);

            await _db.SaveChangesAsync();

            return result.Entity;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}
