using BinocsTest.Core.Model.Entities;
using BinocsTest.Core.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinocsTest.Infrastructure.Repositories.EF
{
    public class EFListItemRepository : IListItemRepository
    {
        private readonly EFListsDbContext _dbContext;

        public EFListItemRepository(EFListsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ListItemEntity entity)
        {
            _dbContext.ListItem.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var listItem = await _dbContext.ListItem.FirstOrDefaultAsync(item => item.Id == id);
            if (listItem != null)
            {
                _dbContext.ListItem.Remove(listItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ListItemEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.ListItem.FirstOrDefaultAsync(item => id == item.Id);
        }

        public async Task<IEnumerable<ListItemEntity>> GetByListIdAsync(Guid listId)
        {
            return await _dbContext.ListItem.Where(item => item.ListId == listId).ToListAsync();
        }

        public async Task UpdateAsync(ListItemEntity entity)
        {
            var listItem = await _dbContext.ListItem.FirstOrDefaultAsync(item => item.Id == entity.Id);
            listItem.Content = entity.Content;

            _dbContext.ListItem.Update(listItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
