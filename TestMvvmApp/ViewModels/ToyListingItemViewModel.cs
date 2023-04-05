using System.Windows.Input;
using TestMvvmApp.Models;

namespace TestMvvmApp.ViewModels
{
    public class ToyListingItemViewModel : ViewModelBase
    {
        public Toy Toy { get; private set; } //Update with Update() method

        public string ToyName => Toy.Name;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ToyListingItemViewModel(Toy toy, ICommand editCommand)
        {
            Toy = toy;
            EditCommand = editCommand;
        }

        public void Update(Toy toy)
        {
            Toy = toy;

            OnPropertyChanged(nameof(ToyName)); // ToyName depends on Toy
        }
    }
}
