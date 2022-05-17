using BinocsTest.Core.Repository.Repositories.Configuration;

namespace BinocsTest.Infrastructure.Repositories.SQL.Configuration
{
    public class SqlListItemRepoConfiguration : IListItemRepoConfiguration
    {
        public SqlListItemRepoConfiguration(string connectionString)
        {

            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }
    }
}
