using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmApp.ViewModels
{
    public class AddToyViewModel : ViewModelBase
    {
        public ToyDetailsFormViewModel ToyDetailsFormViewModel { get; }

        public AddToyViewModel()
        {
            ToyDetailsFormViewModel = new ToyDetailsFormViewModel();
        }
    }
}
