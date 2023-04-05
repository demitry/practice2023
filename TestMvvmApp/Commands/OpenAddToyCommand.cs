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
        private readonly ToysStore _toysStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddToyCommand(ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
            _toysStore = toysStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddToyViewModel addToyViewModel = new AddToyViewModel(_toysStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addToyViewModel;
        }
    }
}
