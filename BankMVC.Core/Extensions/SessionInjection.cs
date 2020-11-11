using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Extensions
{
    public static class SessionInjection
    {
        public static IServiceCollection ConfigureSession(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            return services;
        }
    }
}