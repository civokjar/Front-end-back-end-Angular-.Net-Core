using BinocsTest.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BinocsTest.Infrastructure.Repositories.EF
{
    public class EFListsDbContext : DbContext
    {
        public DbSet<ListEntity> List { get; private set; }
        public DbSet<ListItemEntity> ListItem { get; private set; }

        public EFListsDbContext(DbContextOptions<EFListsDbContext> options) : base(options) { }
    }
}
