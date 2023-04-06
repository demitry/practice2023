using Toys.Domain.Commands;
using Toys.EntityFramework.DTOs;

namespace Toys.EntityFramework.Commands
{
    public class DeleteToyCommand : IDeleteToyCommand
    {
        private readonly ToysDbContextFactory _contextFactory;

        public DeleteToyCommand(ToysDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                ToyDto toyDto = new ToyDto() { Id = id };
                context.Toys.Remove(toyDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
