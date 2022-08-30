using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;

namespace AspBackend.Services.Interface
{
    public interface ITodoServices
    {
        public Task<Todo> CreateTask(TodoViewModel model);
    }
}
