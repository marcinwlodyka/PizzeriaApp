using System;
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
    
    public NavigationStore()
    {
        _currentViewModel = new MenuViewModel();
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}