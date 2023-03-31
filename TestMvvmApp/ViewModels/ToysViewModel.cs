using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestMvvmApp.ViewModels
{
    public class ToysViewModel : ViewModelBase
    {
        public ToysListingViewModel ToysListingViewModel { get; }
        public ToyDetailsViewModel ToyDetailsViewModel { get;  }

        public ICommand AddToyCommand { get; }

        public ToysViewModel()
        {
            ToysListingViewModel = new ToysListingViewModel();
            ToyDetailsViewModel = new ToyDetailsViewModel();
        }
    }
}
