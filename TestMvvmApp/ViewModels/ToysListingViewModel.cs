using System.Collections.ObjectModel;
using TestMvvmApp.Models;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class ToysListingViewModel: ViewModelBase
    {
        private readonly ToysStore _toysStore;

        private readonly ObservableCollection<ToyListingItemViewModel> _toyListingItemViewModels;

        private readonly SelectedToyStore _selectedToyStore;
        private readonly ModalNavigationStore _modalNavigationStore;

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

        public ToysListingViewModel(ToysStore toysStore, SelectedToyStore selectedToyStore, ModalNavigationStore modalNavigationStore)
        {
            _toysStore = toysStore;
            _selectedToyStore = selectedToyStore;
            _modalNavigationStore = modalNavigationStore;
            _toyListingItemViewModels = new ObservableCollection<ToyListingItemViewModel>();

            _toysStore.ToyAdded += ToysStore_ToyAdded;
            _toysStore.ToyUpdated += ToysStore_ToyUpdated;
        }

        private void ToysStore_ToyUpdated(Toy toy)
        {
            ToyListingItemViewModel? toyListingItemViewModel = ToyListingItemViewModels.FirstOrDefault(t => t.Toy.Id == toy.Id);
            if(null != toyListingItemViewModel)
            {
                toyListingItemViewModel.Update(toy);
            }
        }

        protected override void Dispose()
        {
            _toysStore.ToyAdded -= ToysStore_ToyAdded;
            _toysStore.ToyUpdated -= ToysStore_ToyUpdated;

            base.Dispose();
        }

        private void ToysStore_ToyAdded(Toy toy)
        {
            AddToy(toy);
        }

        private void AddToy(Toy toy)
        {
            ToyListingItemViewModel itemViewModel = new ToyListingItemViewModel(toy, _toysStore, _modalNavigationStore);
            _toyListingItemViewModels.Add(itemViewModel);
        }

    }
}
