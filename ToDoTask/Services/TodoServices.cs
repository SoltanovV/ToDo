namespace AspBackend.Services;

public class TodoServices : ITodoServices
{
    ApplicationContext _db;
    public TodoServices(ApplicationContext db)
    {
        _db = db;
    }
    public async Task<Todo> CreateTodoAsync(Todo model)
    {
        try
        {
            if (model.Status is not null & model.Priority is not null)
            {
                var todoCreated = await _db.Todo.AddAsync(model);

                await _db.SaveChangesAsync();

                var created = await _db.Todo
                                        .SingleOrDefaultAsync(t => t.Id == todoCreated.Entity.Id);

                return created;
            }

            throw new Exception("Не все поля заполнены");
          
        }
        catch
        {
            throw;
        }
    }

    public async Task<Todo> UpdateTodoAsync(Todo todo)
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
    public async Task<Todo> DeleteTodoAsync(int id)
    {
        try
        {
            var deleted = await _db.Todo.FirstOrDefaultAsync(t => t.Id == id);

            if (deleted is not null)
            {
                var result = _db.Todo.Remove(deleted);

                await _db.SaveChangesAsync();

                return result.Entity;
            }

            throw new Exception("Задача не найдена");
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
            var user = await _db.User.FirstOrDefaultAsync(u => u.Id == model.UserId);

            var todo = await _db.Todo.FirstOrDefaultAsync(t => t.Id == model.TodoId);

            if (user is not null & todo is not null)
            {
                var result = await _db.UsersTodos.AddAsync(model);

                await _db.SaveChangesAsync();

                return result.Entity;
            }

            throw new Exception("Задача или пользователь не найден");

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
            var user = await _db.User.FirstOrDefaultAsync(u => u.Id == model.UserId);

            if (user is not null)
            {
                var result = _db.UsersTodos.Remove(model);

                await _db.SaveChangesAsync();

                return result.Entity;
            }

            throw new Exception("Пользователь не найден");


        }
        catch
        {
            throw;
        }
       
    }
}
