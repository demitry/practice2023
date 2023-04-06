namespace Toys.Domain.Commands
{
    public interface IDeleteToyCommand
    {
        Task Execute(Guid id);
    }
}
