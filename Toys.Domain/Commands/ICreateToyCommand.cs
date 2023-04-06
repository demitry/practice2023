using Toys.Domain.Models;

namespace Toys.Domain.Commands
{
    public interface ICreateToyCommand
    {
        Task Execute(Toy toy);
    }
}
