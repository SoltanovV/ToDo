using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspBackend.Services.Interface
{
    public interface ITodoServices
    {
        public Task<Todo> CreateTodoAsync(Todo model);
        public Task<Todo> UpdateTodoAsync(Todo model);
        public Task<Todo> DeleteTodoAsync(int id);

        public Task<UserTodo> AddUser(UserTodo model);
        public Task<UserTodo> DeleteUser(UserTodo model);
    }
}
