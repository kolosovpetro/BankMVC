using System;
using BankMVC.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankMVC.Data.Extensions
{
    public static class DataLayerWithSqlServer
    {
        public static IServiceCollection AddDataLayerWithSqlServer(this IServiceCollection services,
            IConfiguration configuration)
        {
            var environmentConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            services.AddDbContext<SqlServerContext>(options =>
                options.UseSqlServer(environmentConnectionString ??
                                     configuration.GetConnectionString("LOCAL_SQLSERVER_CONNECTION_STRING")));
            services.AddTransient<DbContext, SqlServerContext>();
            return services;
        }
    }
}