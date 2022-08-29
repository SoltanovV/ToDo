using AspBackend.Interface;
using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using AspBackend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace AspBackend.Services
{
    public class UserServices
    {
        private ApplicationContext _db;

        public UserServices(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Account> CreateUser(User user)
        {
            try
            {
                var createdUser = await _db.User.AddAsync(user);

                await _db.SaveChangesAsync();

                var created = await _db.User
                  .Include(u => u.Account)
                  .SingleOrDefaultAsync(u => u.Id == createdUser.Entity.Id);

                return created.Account;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
