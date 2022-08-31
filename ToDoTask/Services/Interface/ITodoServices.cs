using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspBackend.Services.Interface
{
    public interface ITodoServices
    {
        public Task<Todo> CreateTodo(TodoViewModel model);

        public Task<Todo> UpdateTodo(int id, TodoViewModel model);
    }
}
