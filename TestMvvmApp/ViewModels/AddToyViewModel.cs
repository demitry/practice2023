using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMvvmApp.Commands;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class AddToyViewModel : ViewModelBase
    {
        public ToyDetailsFormViewModel ToyDetailsFormViewModel { get; }

        public AddToyViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddToyCommand(modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ToyDetailsFormViewModel = new ToyDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
