namespace AspBackend.Services ;

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
                var searcgLogin = await _db.User.SingleOrDefaultAsync(u => u.Login == user.Login);

                if (searcgLogin is not null) throw new WorkingDataException("Такой логин уже существует");


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
                var user = _db.User.SingleOrDefaultAsync(u => u.Id == model.Id);

                if (user is null) throw new WorkingDataException("Не удалось найти пользователя");

                var updateUser = _db.User.Update(model);

                var account = _db.Account.Update(model.Account);

                await _db.SaveChangesAsync();

                var created = await _db.User
                    .SingleOrDefaultAsync(u => u.Id == user.Id);

                return created;
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

                if (search is null) throw new WorkingDataException("Не удалось найти пользователя");

                var result = _db.User.Remove(search);

                await _db.SaveChangesAsync();

                return search;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Account> AuthorizationAccountAsync(int userId)
        {
            try
            {
                var compareUser = await _db.User
                    .Include(u => u.Account)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(u => u.Id == userId);

                if (compareUser is not null || compareUser.Account is not null)
                    return compareUser.Account;
                throw new WorkingDataException("Пользователь не найден");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Account> AuthorizationAccountAsync(User user)
        {
            try
            {
                var compareUser = await _db.User.Include(u => u.Account)
                    .AsNoTracking()
                    .SingleAsync(u => u.Login == user.Login
                                      && u.Password == user.Password);
                if (compareUser is not null || compareUser.Account is not null)
                    return compareUser.Account;
                throw new WorkingDataException("Пользователь не найден");
            }
            catch
            {
                throw;
            }
        }
    }