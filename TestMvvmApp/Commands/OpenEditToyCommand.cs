using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMvvmApp.Models;
using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;

namespace TestMvvmApp.Commands
{
    internal class OpenEditToyCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ToyListingItemViewModel _toyListingItemViewModel;
        private readonly ToysStore _toysStore;

        public OpenEditToyCommand(ToyListingItemViewModel toyListingItemViewModel, ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
            _toyListingItemViewModel = toyListingItemViewModel;
            _toysStore = toysStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            Toy toy = _toyListingItemViewModel.Toy;
            EditToyViewModel editToyViewModel = new EditToyViewModel(toy, _toysStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = editToyViewModel;
        }
    }
}
