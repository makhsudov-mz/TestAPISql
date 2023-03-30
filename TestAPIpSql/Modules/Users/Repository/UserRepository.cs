using TestAPISql.Modules.Users.Entity;
using Microsoft.EntityFrameworkCore;

namespace TestAPISql.Modules.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetUserByIdAsync(int id) => 
            await _appDbContext.Users.FindAsync(id);

        public async Task<User?> GetUserByIdAsyncAsNoTracking(int id) => 
            await _appDbContext.Users.
                Where(u => u.Id == id).
                AsNoTracking().
                FirstOrDefaultAsync();

        public async Task<List<User>> GetUsersAsync() => await _appDbContext.Users.ToListAsync();

        public async Task<List<User>> GetUsersAsyncAsNoTracking() => 
            await _appDbContext.Users.AsNoTracking().ToListAsync();

        public async Task<User?> GetUserByIdForUpdate(int id) => 
            await _appDbContext.Users.                                                     
                FromSqlInterpolated($"SELECT * FROM `users` WHERE `id` = {id} FOR UPDATE").                          
                FirstOrDefaultAsync();

        public async Task Delete(User user)
        {
             _appDbContext.Set<User>().Remove(user);

            await SaveAsync();
        }

        public async Task Update(User user)
        {
            _appDbContext.Set<User>().Update(user);

            await SaveAsync();
        }
        
        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
