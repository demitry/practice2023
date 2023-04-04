using System.Configuration;
using System.Data;
using System.Windows;
using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;

namespace TestMvvmApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly SelectedToyStore _selectedToyStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public App()
    {
        _selectedToyStore = new SelectedToyStore();
        _modalNavigationStore = new ModalNavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        ToysViewModel toysViewModel = new ToysViewModel(_selectedToyStore, _modalNavigationStore);
        
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_modalNavigationStore, toysViewModel)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}

