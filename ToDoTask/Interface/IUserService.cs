using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspBackend.Interface
{
    public interface IUserService
    {
        public Task<Account> CreateAccount(User user);
    }
}
