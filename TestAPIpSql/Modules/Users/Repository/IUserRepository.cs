using TestAPISql.Modules.Users.Entity;

namespace TestAPISql.Modules.Users.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
    }
}
