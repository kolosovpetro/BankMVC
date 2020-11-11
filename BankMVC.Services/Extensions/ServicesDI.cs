using BankMVC.Services.Implementations;
using BankMVC.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Services.Extensions
{
    public static class ServicesDi
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IBankService, BankService>();
        }
    }
}