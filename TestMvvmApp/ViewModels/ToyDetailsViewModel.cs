using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmApp.ViewModels
{
    public class ToyDetailsViewModel: ViewModelBase
    {
        public string Name { get; }
        public string Description { get; }
        public string Size { get; }
        public string IsValidDisplay { get; }

        public ToyDetailsViewModel()
        {
            Name = "Yo-yo";
            Description = "Japan Yo-yo";
            Size = "Small";
            IsValidDisplay = "Yes";
        }
    }
}
