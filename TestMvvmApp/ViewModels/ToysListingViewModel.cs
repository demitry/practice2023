using System.Collections.ObjectModel;
using Toys.Domain.Models;
using TestMvvmApp.Stores;
using System.Windows.Input;
using TestMvvmApp.Commands;

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

        public ICommand LoadToysCommand { get; }

        public ToysListingViewModel(ToysStore toysStore, SelectedToyStore selectedToyStore, ModalNavigationStore modalNavigationStore)
        {
            _toysStore = toysStore;
            _selectedToyStore = selectedToyStore;
            _modalNavigationStore = modalNavigationStore;
            _toyListingItemViewModels = new ObservableCollection<ToyListingItemViewModel>();

            LoadToysCommand = new LoadToysCommand(toysStore);
            //LoadToysCommand.Execute();  //Mmmmm... No, use Factory method instead.

            _toysStore.ToysLoaded += ToysStore_ToysLoaded;
            _toysStore.ToyAdded += ToysStore_ToyAdded;
            _toysStore.ToyUpdated += ToysStore_ToyUpdated;
            _toysStore.ToyDeleted += ToysStore_ToyDeleted;
        }

        private void ToysStore_ToyDeleted(Guid id)
        {
            var toyListingItemViewModel = _toyListingItemViewModels.FirstOrDefault(t => t.Toy?.Id == id);

            if (null != toyListingItemViewModel)
            {
                _toyListingItemViewModels.Remove(toyListingItemViewModel);
            }
        }

        private void ToysStore_ToysLoaded()
        {
            _toyListingItemViewModels.Clear();

            foreach (var toy in _toysStore.Toys)
            {
                AddToy(toy);
            }
        }

        public static ToysListingViewModel LoadViewModel(ToysStore toysStore, SelectedToyStore selectedToyStore, ModalNavigationStore modalNavigationStore)
        {
            ToysListingViewModel toysListingViewModel = new ToysListingViewModel(toysStore, selectedToyStore, modalNavigationStore);

            toysListingViewModel.LoadToysCommand.Execute(null);

            return toysListingViewModel;
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
            _toysStore.ToysLoaded -= ToysStore_ToysLoaded;
            _toysStore.ToyAdded -= ToysStore_ToyAdded;
            _toysStore.ToyUpdated -= ToysStore_ToyUpdated;
            _toysStore.ToyDeleted -= ToysStore_ToyDeleted;

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
