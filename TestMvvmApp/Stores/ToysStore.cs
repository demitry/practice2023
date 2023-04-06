using Toys.Domain.Commands;
using Toys.Domain.Models;
using Toys.Domain.Queries;

namespace TestMvvmApp.Stores
{
    public class ToysStore
    {
        private readonly IGetAllToysQuery _getAllToysQuery;
        private readonly ICreateToyCommand _createToyCommand;
        private readonly IUpdateToyCommand _updateToyCommand;
        private readonly IDeleteToyCommand _deleteToyCommand;

        public ToysStore(
            IGetAllToysQuery getAllToysQuery, 
            ICreateToyCommand createToyCommand, 
            IUpdateToyCommand updateToyCommand, 
            IDeleteToyCommand deleteToyCommand)
        {
            _getAllToysQuery = getAllToysQuery;
            _createToyCommand = createToyCommand;
            _updateToyCommand = updateToyCommand;
            _deleteToyCommand = deleteToyCommand;
        }

        public event Action<Toy> ToyAdded;
        public event Action<Toy> ToyUpdated;

        public async Task Add(Toy toy)
        {
            await _createToyCommand.Execute(toy);

            ToyAdded?.Invoke(toy);
        }

        public async Task Update(Toy toy)
        {
            await _updateToyCommand.Execute(toy);

            ToyUpdated?.Invoke(toy);
        }
    }
}
