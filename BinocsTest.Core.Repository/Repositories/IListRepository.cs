using BinocsTest.Core.Model.Entities;

namespace BinocsTest.Core.Repository.Repositories
{
    public interface IListRepository : IDbRepository<ListEntity>
    {
        Task<IEnumerable<ListEntity>> GetAllAsync();
        Task<ListEntity?> GetByNameAsync(string name);

        Task<ListItemsCountEntity> GetTotalListAndItemCount();
    }
}
