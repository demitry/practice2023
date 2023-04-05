using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMvvmApp.Stores;

namespace TestMvvmApp.Commands
{
    public class AddToyCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddToyCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            //Add Toy to the database
            
            _modalNavigationStore.Close();
        }
    }
}
