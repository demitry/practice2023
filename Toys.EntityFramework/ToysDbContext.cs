using Microsoft.EntityFrameworkCore;
using Toys.EntityFramework.DTOs;

namespace Toys.EntityFramework
{
    public class ToysDbContext: DbContext
    {
        public ToysDbContext(DbContextOptions options) : base (options) { }

        public DbSet<ToyDto> Toys { get; set; }
    }
}