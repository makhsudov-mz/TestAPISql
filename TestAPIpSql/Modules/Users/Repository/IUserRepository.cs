using TestAPISql.Modules.Users.Entity;

namespace TestAPISql.Modules.Users.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByIdForUpdate(int id);
        Task<User?> GetUserByIdAsyncAsNoTracking(int id);

        Task<List<User>> GetUsersAsync();
        Task<List<User>> GetUsersAsyncAsNoTracking();

        Task Delete(User user);
        Task Update(User user);

        Task SaveAsync();
    }
}
