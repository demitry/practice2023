using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMvvmApp.Stores;

namespace TestMvvmApp.Commands
{
    public class EditToyCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditToyCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            //Edit Toy in the database

            _modalNavigationStore.Close();
        }
    }
}
