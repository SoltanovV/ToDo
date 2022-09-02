using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspBackend.Services.Interface
{
    public interface ITodoServices
    {
        public Task<Todo> CreateTodo(Todo model);
        public Task<Todo> UpdateTodo(Todo model);
        public Task<Todo> DeleteTodo(int id);

        public Task<UserTodo> AddUser(UserTodo model);
        public Task<UserTodo> DeleteUser(UserTodo model);
    }
}
