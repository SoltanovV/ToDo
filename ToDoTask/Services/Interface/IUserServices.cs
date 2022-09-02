using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspBackend.Services.Interface
{
    public interface IUserServices
    {
        public Task<Account> CreateAccount(AccountViewModel model);

        public Task<User> UpdateUser(UserViewModel model);

        public Task<User> DeleteUserAsync(int id);
    }
}
