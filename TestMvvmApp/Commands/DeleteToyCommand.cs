using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;
using Toys.Domain.Models;

namespace TestMvvmApp.Commands
{
    internal class DeleteToyCommand : AsyncCommandBase
    {
        private readonly ToyListingItemViewModel _toyListingItemViewModel;
        private readonly ToysStore _toysStore;

        public DeleteToyCommand(ToyListingItemViewModel toyListingItemViewModel, ToysStore toysStore)
        {
            _toyListingItemViewModel = toyListingItemViewModel;
            _toysStore = toysStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Toy toy = _toyListingItemViewModel.Toy;

            try
            {
                await _toysStore.Delete(toy.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
