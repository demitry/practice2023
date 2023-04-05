using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMvvmApp.Commands;
using TestMvvmApp.Models;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class EditToyViewModel : ViewModelBase
    {
        public ToyDetailsFormViewModel ToyDetailsFormViewModel { get; }

        public EditToyViewModel(Toy toy, ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
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
