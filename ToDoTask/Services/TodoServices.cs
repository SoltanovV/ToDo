using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using AspBackend.Services.Interface;
using AspBackend.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace AspBackend.Services
{
    public class TodoServices: ITodoServices
    {
        ApplicationContext _db;
        public TodoServices(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Todo> CreateTodo(TodoViewModel model)
        {
            try
            {
                var map = AutomapperUtil<TodoViewModel, Todo>.Map(model);
                var todoCreated = await _db.AddAsync(map);

                await _db.SaveChangesAsync();

                var created = await _db.Todo
                    .SingleOrDefaultAsync(t => t.Id == todoCreated.Entity.Id);

                return created;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Todo> UpdateTodo(int id, TodoViewModel model)
        {
            try
            {
                Todo todo = AutomapperUtil<TodoViewModel,Todo>.Map(model);        

                _db.Todo.Update(todo);
                
                await _db.SaveChangesAsync();

                var update = _db.Todo.FirstOrDefault(t => t.Id == id);

                return update;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
