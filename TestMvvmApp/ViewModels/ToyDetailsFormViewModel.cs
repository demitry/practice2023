using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestMvvmApp.ViewModels
{
    public class ToyDetailsFormViewModel: ViewModelBase
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set 
			{
                _name = value;
				OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanSubmit)); // CanSubmit is dependent on Name property
            }
		}

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _size;

        public string Size
        {
            get { return _size; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        private bool _isValid;

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool CanSubmit => !string.IsNullOrWhiteSpace(Name);

        public ICommand SubmitCommand { get; }
        
        public ICommand CancelCommand { get; }
        
        public ToyDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
