using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMvvmApp.Commands;
using TestMvvmApp.Models;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class ToysListingViewModel: ViewModelBase
    {
        private readonly ObservableCollection<ToyListingItemViewModel> _toyListingItemViewModels;
        private readonly SelectedToyStore _selectedToyStore;

        public IEnumerable<ToyListingItemViewModel> ToyListingItemViewModels => _toyListingItemViewModels;

        private ToyListingItemViewModel _selectedToyListingItemViewModel;
        public ToyListingItemViewModel SelectedToyListingItemViewModel
        {
            get => _selectedToyListingItemViewModel;
            set
            {
                _selectedToyListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedToyListingItemViewModel));

                _selectedToyStore.SelectedToy = _selectedToyListingItemViewModel?.Toy;
            }
        }

        public ToysListingViewModel(SelectedToyStore selectedToyStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedToyStore = selectedToyStore;
            _toyListingItemViewModels = new ObservableCollection<ToyListingItemViewModel>();
            AddToy(new Toy(name: "Yo-yo", description: "Japanese yo-yo", size: "Small", isValid: true), modalNavigationStore);
            AddToy(new Toy(name: "Car", description: "Test Car", size: "Medium", isValid: true), modalNavigationStore);
            AddToy(new Toy(name: "Track", description: "Test Track", size: "Large", isValid: true), modalNavigationStore);
            AddToy(new Toy(name: "Gun", description: "Not a toy", size: "Small", isValid: false), modalNavigationStore);
        }

        private void AddToy(Toy toy, ModalNavigationStore modalNavigationStore)
        {
            ICommand editCommand = new OpenEditToyCommand(toy, modalNavigationStore);
            _toyListingItemViewModels.Add(new ToyListingItemViewModel(toy, editCommand));
        }

    }
}
