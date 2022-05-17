using BinocsTest.Core.Model.Entities;

namespace BinocsTest.Core.Repository.Repositories
{
    public interface IListItemRepository : IDbRepository<ListItemEntity>
    {
        Task<IEnumerable<ListItemEntity>> GetByListIdAsync(Guid listId);
    }
}
