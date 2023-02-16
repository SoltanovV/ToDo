namespace AspBackend.Services.Interface;

public interface IUserServices
{
    public Task<Account> CreateAccountAsync(User model);

    public Task<User> UpdateUserAsync(User model);

    public Task<User> DeleteUserAsync(int id);
}
