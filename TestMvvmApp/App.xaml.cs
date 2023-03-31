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

    public App()
    {
        _selectedToyStore = new SelectedToyStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new ToysViewModel(_selectedToyStore)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}

