using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestMvvmApp.ViewModels
{
    public class ToyListingItemViewModel : ViewModelBase
    {
        public string ToyName { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ToyListingItemViewModel(string toyName)
        {
            ToyName = toyName;
        }
    }
}
