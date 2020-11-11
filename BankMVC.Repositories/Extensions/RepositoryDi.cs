using BankMVC.Repositories.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Repositories.Extensions
{
    public static class RepositoryDi
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<UserRepository, UserRepository>();
            services.AddTransient<TransactionRepository, TransactionRepository>();
            return services;
        }
    }
}