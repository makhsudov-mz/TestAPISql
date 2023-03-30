using TestAPISql.Modules.Users.Entity;
using TestAPISql.Modules.Users.Repository;


namespace TestAPISql.Modules.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _appDbContext;

        public UserService(IUserRepository userRepository, 
            AppDbContext appDbContext)
        {
            _userRepository = userRepository;
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsyncAsNoTracking(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> UpdateUserAsNoTracking(int id)
        {
            using(var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                WrireLog("Start transaction >>> UpdateUserAsNoTracking");
                try
                {
                    WrireLog("UpdateUserAsNoTracking >>> GetUserByIdAsyncAsNoTracking ");
                    var user = await _userRepository.GetUserByIdAsyncAsNoTracking(id);

                    if(user == null)
                        return null;

                    user.Login = $"asNoTracking {id}";

                    WrireLog("SaveChangesAsync  >> UpdateUserAsNoTracking");

                    await Task.Delay(2000);

                    await _appDbContext.SaveChangesAsync();

                    transaction.Commit();
    
                    WrireLog("Commit transaction >> UpdateUserAsNoTracking");

                    return user;
                }
                catch(Exception ex )
                {
                    Console.WriteLine($"Eror: {ex.Message}");
                    transaction.Rollback();

                    return null;
                }
            }
        }
        public async Task<User> UpdateUser(int id)
        {
            using(var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                WrireLog("Start transaction >> UpdateUser");
                try
                {
                    WrireLog("UpdateUser >> GetUserByIdAsync");
                    var user = await _userRepository.GetUserByIdAsync(id);
                    

                    if(user == null)
                        return null;

                    user.Login = $"Update {id}";

                    WrireLog("SaveChangesAsync  >> UpdateUser");

                    await Task.Delay(20000);

                    await _appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    WrireLog("Commit transaction >> UpdateUser");
                    return user;

                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Eror: {ex.Message}");
                    transaction.Rollback();

                    return null;
                }
            }
        }

        public async Task<User> UpdateUserForUpdate(int id)
        {
            using(var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                WrireLog("Start transaction >> UpdateUserForUpdate");
                try
                {
                    WrireLog("UpdateUserForUpdate >> GetUserByIdForUpdate");
                    var user = await _userRepository.GetUserByIdForUpdate(id);


                    if(user == null)
                        return null;

                    user.Login = $"ForUpdate {id}";

                    WrireLog("SaveChangesAsync  >> UpdateUserForUpdate");

                    await Task.Delay(20000);

                    await _appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    WrireLog("Commit transaction >> UpdateUserForUpdate");
                    return user;

                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Eror: {ex.Message}");
                    transaction.Rollback();

                    return null;
                }
            }
        }
        public async Task<int?> DeleteUserByIdAsync(int id)
        {
            using(var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                WrireLog("Start transaction  DeleteUserByIdAsync");
                try
                {
                    WrireLog("DeleteUserByIdAsync >> GetUserByIdAsync");
                    var user = await _userRepository.GetUserByIdAsync(id);
                    if(user == null)
                    {
                        transaction.Commit();
                        return 0;
                    }

                    await _userRepository.Delete(user);

                    WrireLog("Delay");

                    await Task.Delay(2000);

                    transaction.Commit();

                    WrireLog("Commit transaction >> DeleteUserByIdAsync");
                    return user.Id;

                }
                catch(Exception ex)
                {
                    transaction.Rollback();

                    WrireLog($"Eror: {ex.Message}");

                    return -1;
                }
            }
        }

        private void WrireLog(string str)
        {
            Console.WriteLine($"Message <<<< { str } >>>>");
        }
    }
}
