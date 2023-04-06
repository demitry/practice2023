using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Toys.EntityFramework
{
    public class ToysDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToysDbContext>
    {
        public ToysDbContext CreateDbContext(string[] args = null)
        {
            return new ToysDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Toys.db").Options);
        }
    }
}
