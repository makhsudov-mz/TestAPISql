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
                try
                {

                    var user = await _userRepository.GetUserByIdAsyncAsNoTracking(id);

                    if(user == null)
                        return null;

                    user.Login = $"asNoTracking {id}";

                    await _appDbContext.SaveChangesAsync();

                    await Task.Delay(2000);

                    transaction.Commit();
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
                try
                {

                    var user = await _userRepository.GetUserByIdAsync(id);

                    if(user == null)
                        return null;

                    user.Login = $"Update {id}";

                    await _appDbContext.SaveChangesAsync();

                    await Task.Delay(2000);

                    transaction.Commit();
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
                try
                {
                    var user = await _userRepository.GetUserByIdForUpdate(id);

                    if(user == null)
                    {
                        transaction.Commit();
                        return 0;
                    }

                    await _userRepository.Delete(user);

                    await Task.Delay(20000);

                    transaction.Commit();

                    return user.Id;

                }
                catch(Exception ex)
                {
                    transaction.Rollback();

                    Console.WriteLine($"Eror: {ex.Message}");

                    return -1;
                }
            }
        }
    }
}
