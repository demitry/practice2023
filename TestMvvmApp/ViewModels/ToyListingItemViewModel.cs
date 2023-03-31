using System.Windows.Input;
using TestMvvmApp.Models;

namespace TestMvvmApp.ViewModels
{
    public class ToyListingItemViewModel : ViewModelBase
    {
        public Toy Toy { get; }

        public string ToyName => Toy.Name;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ToyListingItemViewModel(Toy toy)
        {
            Toy = toy;
        }
    }
}
