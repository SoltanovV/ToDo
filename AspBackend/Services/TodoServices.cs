using System.Diagnostics.CodeAnalysis;

namespace AspBackend.Services ;

    public class TodoServices : ITodoServices
    {
        private ApplicationContext _db;

        public TodoServices(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Todo> CreateTodoAsync(Todo model)
        {
            try
            {
                if (!(model.Status is not null & model.Priority is not null))
                    throw new WorkingDataException("Не все поля заполнены");

                var todoCreated = await _db.Todo.AddAsync(model);

                await _db.SaveChangesAsync();

                var created = await _db.Todo
                    .FirstAsync(t => t.Id == todoCreated.Entity.Id);

                return created;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Todo> UpdateTodoAsync(Todo model)
        {
            try
            {
                var todo = await _db.Todo.SingleOrDefaultAsync(t => t.Id == model.Id);

                if (todo is null) throw new WorkingDataException("Не удалось найти задачу");
                var updateTodo = _db.Todo.Update(todo);

                await _db.SaveChangesAsync();

                return updateTodo.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Todo> DeleteTodoAsync(int id)
        {
            try
            {
                var deleted = await _db.Todo.FirstOrDefaultAsync(t => t.Id == id);

                if (deleted is null) throw new WorkingDataException("Задача не найдена");

                var result = _db.Todo.Remove(deleted);

                await _db.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserTodo> AddUserAsync(UserTodo model)
        {
            try
            {
                var user = await _db.User.FirstOrDefaultAsync(u => u.Id == model.AccountId);

                var todo = await _db.Todo.FirstOrDefaultAsync(t => t.Id == model.TodoId);

                if (user is null || todo is null) throw new WorkingDataException("Задача или пользователь не найден");

                var result = await _db.UsersTodos.AddAsync(model);

                await _db.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserTodo> DeleteUserAsync(UserTodo model)
        {
            try
            {
                var user = await _db.User.FirstOrDefaultAsync(u => u.Id == model.AccountId);

                if (user is null) throw new WorkingDataException("Пользователь не найден");

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