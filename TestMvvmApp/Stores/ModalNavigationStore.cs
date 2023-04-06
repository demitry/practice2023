using TestMvvmApp.ViewModels;

namespace TestMvvmApp.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            { 
                return _currentViewModel; 
            }
            set 
            { 
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
                //TODO: We should have disposed the previous CurrentViewModel before setting! 
                //ex: _currentViewModel.Dispose();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

        internal void Close()
        {
            CurrentViewModel = null;
        }
    }
}
