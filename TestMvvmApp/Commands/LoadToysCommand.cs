using TestMvvmApp.Stores;

namespace TestMvvmApp.Commands
{
    public class LoadToysCommand : AsyncCommandBase
    {
        private readonly ToysStore _toysStore;

        public LoadToysCommand(ToysStore toysStore)
        {
            _toysStore = toysStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _toysStore.Load();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
