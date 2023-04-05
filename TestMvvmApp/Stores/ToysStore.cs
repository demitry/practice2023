using TestMvvmApp.Models;

namespace TestMvvmApp.Stores
{
    public class ToysStore
    {
        public event Action<Toy> ToyAdded;

        public async Task Add(Toy toy)
        {
            ToyAdded?.Invoke(toy);
        }
    }
}
