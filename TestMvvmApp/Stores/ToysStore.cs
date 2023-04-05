using TestMvvmApp.Models;

namespace TestMvvmApp.Stores
{
    public class ToysStore
    {
        public event Action<Toy> ToyAdded;
        public event Action<Toy> ToyUpdated;

        public async Task Add(Toy toy) //Create
        {
            ToyAdded?.Invoke(toy);
        }

        public async Task Update(Toy toy)
        {
            ToyUpdated?.Invoke(toy);
        }
    }
}
