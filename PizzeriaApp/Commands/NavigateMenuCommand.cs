using PizzeriaApp.Models;
using PizzeriaApp.Stores;
using PizzeriaApp.ViewModels;

namespace PizzeriaApp.Commands;

public class NavigateMenuCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private readonly ContextFactory _contextFactory;

    public NavigateMenuCommand(NavigationStore navigationStore, ContextFactory contextFactory)
    {
        _navigationStore = navigationStore;
        _contextFactory = contextFactory;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new MenuViewModel(_contextFactory);
    }
}