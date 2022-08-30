using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using AspBackend.Services.Interface;
using AspBackend.Utilities;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace AspBackend.Services
{
    public class UserServices : IUserServices
    {
        private ApplicationContext _db;

        public UserServices(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Account> CreateAccount(AccountViewModel model)
        {
            try
            {
                var map = AutomapperUtil<AccountViewModel, Account>.Map(model);
                var createdAccount = await _db.Account.AddAsync(map);

                await _db.SaveChangesAsync();

                var created = await _db.Account
                    .SingleOrDefaultAsync(u => u.Id == createdAccount.Entity.Id);

                return created;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<User> UpdateUser(UserViewModel model)
        {
            try
            {

                var result = AutomapperUtil<UserViewModel, User>.Map(model);
                _db.User.Update(result);
                await _db.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            try
            {

                var search = await _db.User.FirstOrDefaultAsync(u => u.Id == id);

                var result = _db.User.Remove(search);

                await _db.SaveChangesAsync();

                return search;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
