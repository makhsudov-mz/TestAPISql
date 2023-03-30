using TestAPISql.Modules.Users.Entity;

namespace TestAPISql.Modules.Users.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task<User> UpdateUserAsNoTracking(int id);
        Task<User> UpdateUser(int id);
        Task<int?> DeleteUserByIdAsync(int id);
    }
}
