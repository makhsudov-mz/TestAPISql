using TestAPISql.Modules.Users.Repository;
using TestAPISql.Modules.Users.Services;

namespace TestAPISql.Modules.Users.Extensions
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddUserServiceCollections(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
