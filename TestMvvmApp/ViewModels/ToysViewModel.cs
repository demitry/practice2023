using System.Windows.Input;
using TestMvvmApp.Commands;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class ToysViewModel : ViewModelBase
    {
        public ToysListingViewModel ToysListingViewModel { get; }
        public ToyDetailsViewModel ToyDetailsViewModel { get;  }

        public ICommand AddToyCommand { get; }

        public ToysViewModel(ToysStore toysStore, SelectedToyStore selectedToyStore, ModalNavigationStore modalNavigationStore)
        {
            //TODO: Implement DI
            ToysListingViewModel = ToysListingViewModel.LoadViewModel(toysStore, selectedToyStore, modalNavigationStore);
            ToyDetailsViewModel = new ToyDetailsViewModel(selectedToyStore);

            AddToyCommand = new OpenAddToyCommand(toysStore, modalNavigationStore);
        }
    }
}
