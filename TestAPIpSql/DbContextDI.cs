using Microsoft.EntityFrameworkCore;

namespace TestAPISql
{
    public static class DbContextDI
    {
        public static IServiceCollection AddAppDbContectCollection(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            service.AddDbContext<AppDbContext>(options =>
              options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).
            LogTo(Console.WriteLine, LogLevel.Information));

            return service;
        }
    }
}
