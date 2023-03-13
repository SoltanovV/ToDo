namespace AspBackend.Services ;

    public class ProjectServices : IProjectServices
    {
        private readonly ApplicationContext _db;

        public ProjectServices(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Project> CreateProjectAsync(Project model)
        {
            try
            {
                var created = await _db.Project.AddAsync(model);

                await _db.SaveChangesAsync();

                var result = await _db.Project.FirstOrDefaultAsync(p => p.Id == created.Entity.Id);

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
                var project = await _db.Project.SingleOrDefaultAsync(p => p.Id == model.Id);

                if (project is null) throw new WorkingDataException("Не удалось найти проект");

                var updateProject = _db.Project.Update(model);

                await _db.SaveChangesAsync();

                return updateProject.Entity;
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
                var deleted = await _db.Project.SingleOrDefaultAsync(t => t.Id == id);

                if (deleted is null) throw new WorkingDataException("Не удалось найти проект");

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
                var user = await _db.User.SingleOrDefaultAsync(u => u.Id == model.AccountId);

                var project = await _db.Project.SingleOrDefaultAsync(p => p.Id == model.ProjectId);

                if (project is null || user is null) throw new WorkingDataException("Не удалось добавить пользователя");

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
                var user = await _db.User.SingleOrDefaultAsync(u => u.Id == model.AccountId);

                var project = await _db.Project.SingleOrDefaultAsync(p => p.Id == model.ProjectId);

                if (project is null || user is null) throw new WorkingDataException("Ошибка удаления");

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