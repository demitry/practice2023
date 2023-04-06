using Toys.Domain.Models;

namespace Toys.Domain.Queries
{
    public interface IGetAllToysQuery
    {
        Task<IEnumerable<Toy>> Execute();
    }
}
