using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMvvmApp.Models;
using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;

namespace TestMvvmApp.Commands
{
    internal class OpenEditToyCommand : CommandBase
    {
        private readonly Toy _toy;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditToyCommand(Toy toy, ModalNavigationStore modalNavigationStore)
        {
            _toy = toy;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            EditToyViewModel editToyViewModel = new EditToyViewModel(_toy, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = editToyViewModel;
        }
    }
}
