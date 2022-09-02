using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspBackend.Services.Interface
{
    public interface IProjectServices
    {
        public Task<Project> CreateProject(Project model);
        public Task<Project> UpdateProject(Project model);
        public Task<Project> DeleteProject(int id);

        public Task<UserProject> AddUserProject(UserProject model);
        public Task<UserProject> DeleteUserProject(UserProject model);
    }
}
