using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmApp.ViewModels
{
    public class ToysListingViewModel: ViewModelBase
    {
        private readonly ObservableCollection<ToyListingItemViewModel> _toyListingItemViewModels;

        public IEnumerable<ToyListingItemViewModel> ToyListingItemViewModels => _toyListingItemViewModels;

        public ToysListingViewModel()
        {
            _toyListingItemViewModels = new ObservableCollection<ToyListingItemViewModel>();
            _toyListingItemViewModels.Add(new ToyListingItemViewModel("Yo-yo"));
            _toyListingItemViewModels.Add(new ToyListingItemViewModel("Car"));
            _toyListingItemViewModels.Add(new ToyListingItemViewModel("Track"));
        }
    }
}
