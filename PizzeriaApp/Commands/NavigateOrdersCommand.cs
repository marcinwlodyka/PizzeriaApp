using PizzeriaApp.Stores;
using PizzeriaApp.ViewModels;

namespace PizzeriaApp.Commands;

public class NavigateOrdersCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;

    public NavigateOrdersCommand(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new OrdersViewModel();
    }
}