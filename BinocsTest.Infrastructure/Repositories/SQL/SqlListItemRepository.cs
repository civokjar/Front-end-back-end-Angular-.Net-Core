using BinocsTest.Core.Model.Entities;
using BinocsTest.Core.Repository.Repositories;
using BinocsTest.Core.Repository.Repositories.Configuration;
using BinocsTest.Infrastructure.Repositories.SQL.Base;

namespace BinocsTest.Infrastructure.Repositories.SQL
{
    public class SqlListItemRepository : BaseSqlRepository, IListItemRepository
    {
        public SqlListItemRepository(IListItemRepoConfiguration configuration) : base(configuration)
        {
        }
        public async Task CreateAsync(ListItemEntity entity)
        {
            var sql = "INSERT INTO dbo.[ListItem](Id, ListId, Content) VALUES (@Id, @ListId, @Content);";

            await ExecuteAsync(sql, entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM dbo.[ListItem] WHERE Id = @id";

            await ExecuteAsync(sql, new { id }).ConfigureAwait(false);
        }

        public async Task<ListItemEntity?> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM dbo.[ListItem] WHERE Id = @id";

            return await QueryFirstOrDefaultAsync<ListItemEntity>(sql, new { id });
        }

        public async Task<IEnumerable<ListItemEntity>> GetByListIdAsync(Guid listId)
        {
            var sql = "SELECT * FROM dbo.[ListItem] WHERE ListId = @listId";

            return await QueryAsync<ListItemEntity>(sql, new { listId });
        }

        public async Task UpdateAsync(ListItemEntity entity)
        {
            var sql = "UPDATE dbo.[ListItem] SET Content = @Content WHERE Id = @Id";

            await ExecuteAsync(sql, entity);
        }
    }
}
