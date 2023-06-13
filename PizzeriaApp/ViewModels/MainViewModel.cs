using System;
using System.Windows.Input;
using PizzeriaApp.Commands;
using PizzeriaApp.Stores;

namespace PizzeriaApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    
    public ICommand NavigateMenuCommand { get; }
    public ICommand NavigateOrdersCommand { get; }
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        NavigateMenuCommand = new NavigateMenuCommand(_navigationStore);
        NavigateOrdersCommand = new NavigateOrdersCommand(_navigationStore);
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}