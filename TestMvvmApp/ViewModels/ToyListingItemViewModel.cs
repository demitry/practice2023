using System.Windows.Input;
using TestMvvmApp.Commands;
using TestMvvmApp.Stores;
using Toys.Domain.Models;

namespace TestMvvmApp.ViewModels
{
    public class ToyListingItemViewModel : ViewModelBase
    {
        public Toy Toy { get; private set; } //Update with Update() method

        public string ToyName => Toy.Name;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ToyListingItemViewModel(Toy toy, ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
            Toy = toy;

            EditCommand = new OpenEditToyCommand(this, toysStore, modalNavigationStore);
        }

        public void Update(Toy toy)
        {
            Toy = toy;

            OnPropertyChanged(nameof(ToyName)); // ToyName depends on Toy
        }
    }
}
