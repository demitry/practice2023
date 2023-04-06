using Toys.Domain.Commands;
using Toys.Domain.Models;
using Toys.EntityFramework.DTOs;
using Toys.EntityFramework.Extensions;

namespace Toys.EntityFramework.Commands
{
    public class CreateToyCommand : ICreateToyCommand
    {
        private readonly ToysDbContextFactory _contextFactory;

        public CreateToyCommand(ToysDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Toy toy)
        {
            using (var context = _contextFactory.Create())
            {
                ToyDto toyDto = toy.ToToyDto();
                context.Toys.Add(toyDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
