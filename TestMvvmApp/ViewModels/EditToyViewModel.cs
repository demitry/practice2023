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
    public class EditToyViewModel : ViewModelBase
    {
        public ToyDetailsFormViewModel ToyDetailsFormViewModel { get; }

        public EditToyViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ToyDetailsFormViewModel = new ToyDetailsFormViewModel(submitCommand: null, cancelCommand);
        }
    }
}
