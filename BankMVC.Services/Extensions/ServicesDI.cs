using BankMVC.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Services.Extensions
{
    public static class ServicesDi
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<BankService, BankService>();
        }
    }
}