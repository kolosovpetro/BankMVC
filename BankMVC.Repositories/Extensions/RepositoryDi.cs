using BankMVC.Repositories.Implementations;
using BankMVC.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Repositories.Extensions
{
    public static class RepositoryDi
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}