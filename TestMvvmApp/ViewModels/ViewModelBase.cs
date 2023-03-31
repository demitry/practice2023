using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TestMvvmApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void Dispose() {}

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            Trace.WriteLine("Property Name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
