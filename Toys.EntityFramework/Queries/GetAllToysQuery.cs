using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Toys.Domain.Models;
using Toys.Domain.Queries;

namespace Toys.EntityFramework.Queries
{
    public class GetAllToysQuery : IGetAllToysQuery
    {
        private readonly ToysDbContextFactory _contextFactory;

        public GetAllToysQuery(ToysDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Toy>> Execute()
        {
            using(var context = _contextFactory.Create())
            {
                var toysDtos = await context.Toys.ToListAsync();

                return toysDtos.Select(t => new Toy(t.Id, t.Name, t.Description, t.Size, t.IsValid));
            }
        }
    }
}
