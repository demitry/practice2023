using Toys.Domain.Models;
using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;

namespace TestMvvmApp.Commands
{
    public class EditToyCommand : AsyncCommandBase
    {
        private readonly ToysStore _toysStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private EditToyViewModel _editToyViewModel;

        public EditToyCommand(EditToyViewModel editToyViewModel, ToysStore toysStore, ModalNavigationStore modalNavigationStore)
        {
            _editToyViewModel = editToyViewModel;
            _toysStore = toysStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            //Add Toy to the database
            ToyDetailsFormViewModel formViewModel = _editToyViewModel.ToyDetailsFormViewModel;

            Toy toy = new Toy(
                _editToyViewModel.ToyId,
                formViewModel.Name,
                formViewModel.Description,
                formViewModel.Size,
                formViewModel.IsValid);

            try
            {
                await _toysStore.Update(toy);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
