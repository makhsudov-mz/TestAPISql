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
            using(var transaction =  _appDbContext.Database.BeginTransaction())
            {
                WrireLog("Start transaction >>> UpdateUserAsNoTracking");
                try
                {
                    WrireLog("UpdateUserAsNoTracking >>> GetUserByIdAsyncAsNoTracking ");
                    var user = await _userRepository.GetUserByIdAsyncAsNoTracking(id);

                    if(user == null)
                        return null;

                    user.Login = $"asNoTracking {id}";

                    WrireLog("UpdateUserAsNoTracking >> Delay");
                    await Task.Delay(2000);

                    WrireLog("SaveChangesAsync  >> UpdateUserAsNoTracking");

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
            using(var transaction =  _appDbContext.Database.BeginTransaction())
            {
                WrireLog("Start transaction >> UpdateUser");
                try
                {
                    WrireLog("UpdateUser >> GetUserByIdAsync");

                    //FormattableString sqlRaw = $"SELECT * FROM `users` WHERE `id` = {id} FOR UPDATE";

                    var user = await _userRepository.GetUserByIdAsync(id);
                    
                    if(user == null)
                        return null;

                    user.Login = $"Update {id}";

                    WrireLog("UpdateUser >> Delay");
                    await Task.Delay(20000);

                    WrireLog("SaveChangesAsync  >> UpdateUser");

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

                    WrireLog("UpdateUserForUpdate >> Delay");
                    await Task.Delay(20000);

                    WrireLog("SaveChangesAsync  >> UpdateUserForUpdate");

                    await _appDbContext.SaveChangesAsync();

                    WrireLog("Seletct  >>> UpdateUserForUpdate");
                    user = await _userRepository.GetUserByIdAsync(id);

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
            using(var transaction =  _appDbContext.Database.BeginTransaction())
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

                    WrireLog("DeleteUserByIdAsync >> Delay");

                    await Task.Delay(2000);

                    WrireLog("DeleteUserByIdAsync >> Delete");

                    await _userRepository.Delete(user);

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
            Console.WriteLine($"Message <<<< { str } >>>> Time {DateTime.Now.ToString("H:mm:fffffff")}");
        }
    }
}
