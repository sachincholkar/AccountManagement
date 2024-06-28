using AccountManagement.Domain.Repository;
using AccountManagement.Infrastructure.Data;
using AccountManagement.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<FakeDataStore>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
