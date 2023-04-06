using Toys.Domain.Models;

namespace Toys.Domain.Commands
{
    public interface IUpdateToyCommand
    {
        Task Execute(Toy toy);
    }
}
