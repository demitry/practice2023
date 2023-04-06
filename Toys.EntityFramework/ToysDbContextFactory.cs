using Microsoft.EntityFrameworkCore;

namespace Toys.EntityFramework
{
    public class ToysDbContextFactory
    {
        private readonly DbContextOptions _options;

        public ToysDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ToysDbContext Create()
        {
            return new ToysDbContext(_options);
        }
    }
}
