using TestAPISql.Modules.Users.Entity;

namespace TestAPISql.Modules.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetUser(int id)
        {
           return await _appDbContext.User.FindAsync(u => u.id == id);
        }
    }
}
