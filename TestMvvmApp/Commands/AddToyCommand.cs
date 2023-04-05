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
    public class AddToyCommand : AsyncCommandBase
    {
        private readonly AddToyViewModel _addToyViewModel;
        private readonly ToysStore _toysStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddToyCommand(AddToyViewModel addToyViewModel, ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
            _addToyViewModel = addToyViewModel;
            _toysStore = toysStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            //Add Toy to the database
            ToyDetailsFormViewModel formViewModel = _addToyViewModel.ToyDetailsFormViewModel;

            Toy toy = new Toy(
                Guid.NewGuid(),
                formViewModel.Name, 
                formViewModel.Description, 
                formViewModel.Size, 
                formViewModel.IsValid);

            try
            {
                await _toysStore.Add(toy);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
