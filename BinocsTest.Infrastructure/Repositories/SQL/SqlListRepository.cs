using BinocsTest.Core.Model.Entities;
using BinocsTest.Core.Repository.Repositories;
using BinocsTest.Core.Repository.Repositories.Configuration;
using BinocsTest.Infrastructure.Repositories.SQL.Base;

namespace BinocsTest.Infrastructure.Repositories.SQL
{
    public class SqlListRepository : BaseSqlRepository, IListRepository
    {

        public SqlListRepository(IListItemRepoConfiguration configuration) : base(configuration)
        {
        }

        public async Task CreateAsync(ListEntity entity)
        {
            var sql = "INSERT INTO dbo.[List](Id, Name) VALUES (@Id, @Name);";

            await ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var sql = @"BEGIN TRY
                            BEGIN TRAN
                                DELETE FROM dbo.[ListItem] WHERE ListId = @id
                                DELETE FROM dbo.[List] WHERE Id = @id
                            COMMIT
                        END TRY
                        BEGIN CATCH
                            ROLLBACK        
                        END CATCH";

            await ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<ListEntity>> GetAllAsync()
        {
            var sql = "SELECT * FROM dbo.[List]";

            return await QueryAsync<ListEntity>(sql, new { });
        }

        public async Task<ListEntity?> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM dbo.[List] WHERE Id = @id";

            return await QueryFirstOrDefaultAsync<ListEntity>(sql, new { id });
        }

        public async Task<ListEntity?> GetByNameAsync(string name)
        {
            var sql = "SELECT * FROM dbo.[List] WHERE Name = @name";
           
            return await QueryFirstOrDefaultAsync<ListEntity>(sql, new { name });
        }

        public async Task<ListItemsCountEntity> GetTotalListAndItemCount()
        {
            var sql = "SELECT (SELECT COUNT(*) FROM List) AS ListsCount, (SELECT COUNT(*) FROM ListItem) AS ItemsCount";

            return await QueryFirstOrDefaultAsync<ListItemsCountEntity>(sql, new { });

        }

        public async Task UpdateAsync(ListEntity entity)
        {
            var sql = "UPDATE dbo.[List] SET Name = @Name WHERE Id = @Id";

            await ExecuteAsync(sql, entity);
        }
    }
}
