using AspBackend.Models.Entity;

namespace AspBackend.Services;

public class UserServices : IUserServices
{
    private ApplicationContext _db;

    public UserServices(ApplicationContext db)
    {
        _db = db;
    }
    public async Task<Account> CreateAccountAsync(User user)
    {
        try
        {

            
            var createdAccount = await _db.Account.AddAsync(user.Account);

            var createdUser = await _db.User.AddAsync(user);

            await _db.SaveChangesAsync();

            var created = await _db.Account
                .SingleOrDefaultAsync(u => u.Id == createdAccount.Entity.Id);

            return created;

        }
        catch
        {
            throw;
        }

    }
    public async Task<User> UpdateUserAsync(User model)
    {
        try
        {



               var user = _db.User.Update(model);

               var account = _db.Account.Update(model.Account);

                await _db.SaveChangesAsync();

                var created = await _db.User
                                    .SingleOrDefaultAsync(u => u.Id == user.Entity.Id);

                return created;
            

            throw new Exception("Не удалось найти пользователя");

        }
        catch
        {
            throw;
        }
    }

    public async Task<User> DeleteUserAsync(int id)
    {
        try
        {

            var search = await _db.User.FirstOrDefaultAsync(u => u.Id == id);

            if (search is not null)
            {
                var result = _db.User.Remove(search);

                await _db.SaveChangesAsync();

                return search;

            }

            throw new Exception("Не удалось найти пользователя");

        }
        catch
        {
            throw;
        }
    }
}
