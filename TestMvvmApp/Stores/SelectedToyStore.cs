using TestMvvmApp.Models;

namespace TestMvvmApp.Stores
{
    public class SelectedToyStore
    {
        private Toy _selectedToy;

        public Toy SelectedToy
        {
            get 
            { 
                return _selectedToy; 
            } 
            set 
            { 
                _selectedToy = value;
                SelectedToyChanged?.Invoke();
            }
        }

        public event Action SelectedToyChanged;
    }
}
