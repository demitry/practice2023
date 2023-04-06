using Toys.Domain.Commands;
using Toys.Domain.Models;
using Toys.EntityFramework.DTOs;
using Toys.EntityFramework.Extensions;

namespace Toys.EntityFramework.Commands
{
    public class UpdateToyCommand : IUpdateToyCommand
    {
        private readonly ToysDbContextFactory _contextFactory;

        public UpdateToyCommand(ToysDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Toy toy)
        {
            using (var context = _contextFactory.Create())
            {
                ToyDto toyDto = toy.ToToyDto();
                context.Toys.Update(toyDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
