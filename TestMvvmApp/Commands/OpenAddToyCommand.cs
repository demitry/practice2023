using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;

namespace TestMvvmApp.Commands
{
    public class OpenAddToyCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddToyCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddToyViewModel addToyViewModel = new AddToyViewModel();

            _modalNavigationStore.CurrentViewModel = addToyViewModel;
        }
    }
}
