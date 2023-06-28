using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PizzeriaApp.Models;
using PizzeriaApp.Stores;
using PizzeriaApp.ViewModels;
using PizzeriaApp.Views;

namespace PizzeriaApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs startupEventArgs)
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        var contextFactory = new ContextFactory();
        var navigationStore = new NavigationStore(contextFactory);

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore, contextFactory)
        };

        MainWindow.Show();
        base.OnStartup(startupEventArgs);
    }
}