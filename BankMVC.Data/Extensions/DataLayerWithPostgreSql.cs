using System;
using BankMVC.Auxiliary.StringParser;
using BankMVC.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Data.Extensions
{
    public static class DataLayerWithPostgreSql
    {
        public static IServiceCollection AddDataLayerWithPostgreSql(this IServiceCollection services,
            IConfiguration configuration)
        {
            var environmentConnectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

            services.AddDbContext<PostgreContext>(options =>
                options.UseNpgsql(
                    StringParser.Convert(environmentConnectionString) ??
                    configuration.GetConnectionString("LOCAL_POSTGRES_CONNECTION_STRING")));

            services.AddTransient<DbContext, PostgreContext>();
            return services;
        }
    }
}