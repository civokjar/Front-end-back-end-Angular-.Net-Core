using BinocsTest.Core.Repository.Repositories.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinocsTest.Infrastructure.Repositories.SQL.Configuration
{
    public class SqlListRepoConfiguration : IListRepoConfiguration
    {
        public SqlListRepoConfiguration(string connectionString) { 
        
            ConnectionString = connectionString;    
        }

        public string ConnectionString { get; private set; }
    }
}
