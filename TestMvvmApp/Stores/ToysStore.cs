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

        public event Action<Toy> ToyAdded;
        public event Action<Toy> ToyUpdated;
        public event Action ToysLoaded;
        public event Action<Guid> ToyDeleted;

        private readonly List<Toy> _toys;
        public IEnumerable<Toy> Toys => _toys;

        public ToysStore(
            IGetAllToysQuery getAllToysQuery, 
            ICreateToyCommand createToyCommand, 
            IUpdateToyCommand updateToyCommand, 
            IDeleteToyCommand deleteToyCommand)
        {
            _toys = new List<Toy>();
            _getAllToysQuery = getAllToysQuery;
            _createToyCommand = createToyCommand;
            _updateToyCommand = updateToyCommand;
            _deleteToyCommand = deleteToyCommand;
        }

        public async Task Load()
        {
            var toys = await _getAllToysQuery.Execute();

            _toys.Clear();
            _toys.AddRange(toys);
            
            ToysLoaded?.Invoke();
        }

        public async Task Add(Toy toy)
        {
            await _createToyCommand.Execute(toy);

            _toys.Add(toy);

            ToyAdded?.Invoke(toy);
        }

        public async Task Update(Toy toy)
        {
            await _updateToyCommand.Execute(toy);

            int currentIndex = _toys.FindIndex(t => t.Id == toy.Id);
            if(currentIndex >= 0)
            {
                _toys[currentIndex] = toy;
            }
            else
            {
                _toys.Add(toy);
            }

            ToyUpdated?.Invoke(toy);
        }

        public async Task Delete(Guid id)
        {
            await _deleteToyCommand.Execute(id);

            _toys.RemoveAll(t => t.Id == id);

            ToyDeleted?.Invoke(id);
        }
    }
}
