using Microsoft.EntityFrameworkCore;
using System.Windows;
using TestMvvmApp.Stores;
using TestMvvmApp.ViewModels;
using Toys.Domain.Commands;
using Toys.Domain.Queries;
using Toys.EntityFramework;
using Toys.EntityFramework.Commands;
using Toys.EntityFramework.Queries;

namespace TestMvvmApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    //Stores
    private readonly ToysStore _toysStore;
    private readonly SelectedToyStore _selectedToyStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    private readonly ToysDbContextFactory _toysDbContextFactory;

    private readonly IGetAllToysQuery _getAllToysQuery;
    private readonly ICreateToyCommand _createToyCommand;
    private readonly IUpdateToyCommand _updateToyCommand;
    private readonly IDeleteToyCommand _deleteToyCommand;

    public App()
    {
        string connectionString = "Data Source=Toys.db";
        
        DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite(connectionString)
                .Options;
        
        _toysDbContextFactory = new ToysDbContextFactory(options);

        _getAllToysQuery = new GetAllToysQuery(_toysDbContextFactory);
        _createToyCommand = new CreateToyCommand(_toysDbContextFactory);
        _updateToyCommand = new UpdateToyCommand(_toysDbContextFactory);
        _deleteToyCommand = new DeleteToyCommand(_toysDbContextFactory);
        
        _toysStore = new ToysStore(
            _getAllToysQuery, 
            _createToyCommand, 
            _updateToyCommand, 
            _deleteToyCommand);
        
        _selectedToyStore = new SelectedToyStore(_toysStore);
        _modalNavigationStore = new ModalNavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using (ToysDbContext context = _toysDbContextFactory.Create())
        {
            context.Database.Migrate();
        }

        ToysViewModel toysViewModel = new ToysViewModel(_toysStore, _selectedToyStore, _modalNavigationStore);
        
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_modalNavigationStore, toysViewModel)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}

