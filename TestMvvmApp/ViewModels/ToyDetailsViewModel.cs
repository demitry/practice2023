using Toys.Domain.Models;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class ToyDetailsViewModel: ViewModelBase
    {
        private readonly SelectedToyStore _selectedToyStore;
        private Toy Selected => _selectedToyStore.SelectedToy;
        public bool HasSelectedToy => Selected != null;

        public string Name => Selected?.Name ?? "Unknown";
        public string Description => Selected?.Description ?? "Unknown";
        public string Size => Selected?.Size ?? "Unknown";
        public string IsValidDisplay => (Selected?.IsValid ?? false) ? "Yes" : "No";

        public ToyDetailsViewModel(SelectedToyStore selectedToyStore)
        {
            _selectedToyStore = selectedToyStore;
            _selectedToyStore.SelectedToyChanged += SelectedToyStore_SelectedToyChanged; //Subscribe
        }

        protected override void Dispose()
        {
            _selectedToyStore.SelectedToyChanged -= SelectedToyStore_SelectedToyChanged; //and Unsubscribe
            base.Dispose();
        }

        private void SelectedToyStore_SelectedToyChanged()
        {
            OnPropertyChanged(nameof(HasSelectedToy));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Size));
            OnPropertyChanged(nameof(IsValidDisplay));
        }
    }
}
