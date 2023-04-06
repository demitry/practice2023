using System.Windows.Input;
using TestMvvmApp.Commands;
using Toys.Domain.Models;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class EditToyViewModel : ViewModelBase
    {
        public Guid ToyId { get; }

        public ToyDetailsFormViewModel ToyDetailsFormViewModel { get; }

        public EditToyViewModel(Toy toy, ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
            ToyId = toy.Id;
            ICommand submitCommand = new EditToyCommand(this, toysStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ToyDetailsFormViewModel = new ToyDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Name = toy.Name,
                Description = toy.Description,
                Size = toy.Size,
                IsValid = toy.IsValid
            };
        }
    }
}
