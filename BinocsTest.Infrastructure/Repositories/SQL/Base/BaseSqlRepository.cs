using BinocsTest.Core.Repository.Repositories;
using BinocsTest.Core.Repository.Repositories.Configuration.Base;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BinocsTest.Infrastructure.Repositories.SQL.Base
{
    public class BaseSqlRepository 
    {
        private string _connectionString;
        public BaseSqlRepository(IBaseRepoConfiguration configuration)
        {

            _connectionString = configuration.ConnectionString;

        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters)
        {
            using (SqlConnection conn = new(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<T>(sql, parameters);
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters)
        {
            using (SqlConnection conn = new(_connectionString))
            {
                return await conn.QueryAsync<T>(sql, parameters);
            }
        }
        public async Task ExecuteAsync(string sql, object parameters)
        {
            using (SqlConnection conn = new(_connectionString))
            {
                await conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}
