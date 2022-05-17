using BinocsTest.Core.Repository.Repositories;
using BinocsTest.Core.Repository.Repositories.Configuration;
using BinocsTest.Infrastructure.Repositories.EF;
using BinocsTest.Infrastructure.Repositories.SQL;
using BinocsTest.Infrastructure.Repositories.SQL.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BinocsTest.Infrastructure.Configuration
{
    public static class RepositoriesRegistrationModule {


        public static IServiceCollection AddEFRepositories(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<EFListsDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString(InfrastructureConstants.ConnectionStringName)));
            services.AddScoped<IListRepository, EFListRepository>();
            services.AddScoped<IListItemRepository, EFListItemRepository>();

            return services;
        }

        public static IServiceCollection AddSqlRepositories(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IListRepoConfiguration>(t=> new SqlListRepoConfiguration(configuration.GetConnectionString(InfrastructureConstants.ConnectionStringName)));
            services.AddScoped<IListRepository, SqlListRepository>();
            
            services.AddSingleton<IListItemRepoConfiguration>(t => new SqlListItemRepoConfiguration(configuration.GetConnectionString(InfrastructureConstants.ConnectionStringName)));
            services.AddScoped<IListItemRepository, SqlListItemRepository>();

            return services;
        }
    }
}
