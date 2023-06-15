﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
        var navigationStore = new NavigationStore();

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
        };
            
        MainWindow.Show();
        base.OnStartup(startupEventArgs);
    }
}