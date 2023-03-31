using System.Configuration;
using System.Data;
using System.Windows;
using TestMvvmApp.ViewModels;

namespace TestMvvmApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new ToysViewModel()
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}

