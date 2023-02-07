using AspBackend.Models.Entity;
using AspBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace AspBackend.Services
{
    public class TodoServices : ITodoServices
    {
        ApplicationContext _db;
        public TodoServices(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Todo> CreateTodo(Todo model)
        {
            try
            {
                var todoCreated = await _db.Todo.AddAsync(model);

                await _db.SaveChangesAsync();

                var created = await _db.Todo
                    .SingleOrDefaultAsync(t => t.Id == todoCreated.Entity.Id);

                return created;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Todo> UpdateTodo(Todo todo)
        {
            try
            {
                var updateTodo = _db.Todo.Update(todo);

                await _db.SaveChangesAsync();

                return updateTodo.Entity;

            }
            catch
            {
                throw;
            }
        }
        public async Task<Todo> DeleteTodo(int id)
        {
            try
            {
                var deleted = await _db.Todo.FirstOrDefaultAsync(t => t.Id == id);

                var result = _db.Todo.Remove(deleted);

                await _db.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserTodo> AddUser(UserTodo model)
        {
            try
            {
                var result = await _db.UsersTodos.AddAsync(model);
                //result.Dispouse();
                await _db.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }

        }
        
        public async Task<UserTodo> DeleteUser(UserTodo model)
        {
            try
            {
                var result = _db.UsersTodos.Remove(model);

                await _db.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
           
        }
    }
}
