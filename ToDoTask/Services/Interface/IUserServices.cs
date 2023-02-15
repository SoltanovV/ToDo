using AspBackend.Models.Entity;

namespace AspBackend.Services.Interface;

public interface IUserServices
{
    public Task<Account> CreateAccountAsync(User model);

    public Task<User> CreateUserAsync(User model);

    public Task<User> DeleteUserAsync(int id);
}
