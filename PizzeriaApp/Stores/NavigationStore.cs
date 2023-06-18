using System;
using PizzeriaApp.Models;
using PizzeriaApp.ViewModels;

namespace PizzeriaApp.Stores;

public class NavigationStore
{
    private ViewModelBase _currentViewModel;
    public event Action? CurrentViewModelChanged;

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public NavigationStore(ContextFactory contextFactory)
    {
        _currentViewModel = new MenuViewModel(contextFactory);
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}