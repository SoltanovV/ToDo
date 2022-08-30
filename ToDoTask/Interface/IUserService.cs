using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;

namespace AspBackend.Interface
{
    public interface IUserService
    {
        public Task<Account> CreateAccount(User user);

        public Task<User> UpdateUser(UserViewModel model);
    }
}
