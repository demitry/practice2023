﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMvvmApp.Stores;

namespace TestMvvmApp.ViewModels
{
    public class ToysViewModel : ViewModelBase
    {
        public ToysListingViewModel ToysListingViewModel { get; }
        public ToyDetailsViewModel ToyDetailsViewModel { get;  }

        public ICommand AddToyCommand { get; }

        public ToysViewModel(SelectedToyStore selectedToyStore)
        {
            ToysListingViewModel = new ToysListingViewModel(selectedToyStore);
            ToyDetailsViewModel = new ToyDetailsViewModel(selectedToyStore);
        }
    }
}
