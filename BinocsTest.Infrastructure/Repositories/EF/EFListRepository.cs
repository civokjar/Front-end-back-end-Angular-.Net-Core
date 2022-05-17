using BinocsTest.Core.Model.Entities;
using BinocsTest.Core.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BinocsTest.Infrastructure.Repositories.EF
{
    public class EFListRepository : IListRepository
    {
        private readonly EFListsDbContext _dbContext;

        public EFListRepository(EFListsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ListEntity entity)
        {
            _dbContext.List.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var list = await _dbContext.List.FirstOrDefaultAsync(list => list.Id == id);
            if (list != null)
            {
                var listItems = await _dbContext.ListItem.Where(item => item.ListId == id).ToListAsync();

                _dbContext.RemoveRange(listItems);
                _dbContext.List.Remove(list);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ListEntity>> GetAllAsync()
        {
            return await _dbContext.List.ToListAsync();
        }

        public async Task<ListEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.List.FirstOrDefaultAsync(list => id == list.Id);
        }

        public async Task<ListEntity?> GetByNameAsync(string name)
        {
            return await _dbContext.List.FirstOrDefaultAsync(list => list.Name == name);
        }

        public async Task<ListItemsCountEntity> GetTotalListAndItemCount()
        {
            var listsCount = await _dbContext.List.CountAsync();
            var itemsCount = await _dbContext.ListItem.CountAsync();

            return new ListItemsCountEntity
            {
                ItemsCount = itemsCount,
                ListsCount = listsCount,
            };
        }

        public async Task UpdateAsync(ListEntity entity)
        {
            var list = await _dbContext.List.FirstOrDefaultAsync(list => list.Id == entity.Id);
            list.Name = entity.Name;

            _dbContext.List.Update(list);
            await _dbContext.SaveChangesAsync();
        }
    }
}
