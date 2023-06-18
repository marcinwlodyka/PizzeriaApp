using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using PizzeriaApp.Commands;
using PizzeriaApp.Models;
using PizzeriaApp.Services;
using PizzeriaApp.Stores;

namespace PizzeriaApp.ViewModels;

public struct FormattedPizza
{
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Price { get; set; }
}

public class SelectableIngredient : Ingredient
{
    public bool IsSelected { get; set; }
}

public class MenuViewModel : ViewModelBase
{
    private readonly PizzaService _pizzaService;
    private readonly PizzaStore _pizzaStore;

    public IEnumerable<FormattedPizza> Pizzas => _GetFormattedPizzas(_pizzaStore.Pizzas);
    public List<SelectableIngredient> Ingredients { get; private set; } = new();
    public ICommand AddPizzaCommand { get; }

    public string? InputName { get; set; }
    private float? _inputPrice;

    public float? InputPrice
    {
        get => _inputPrice;
        set => _inputPrice = float.TryParse(value.ToString(), out var parsed) ? parsed : null;
    }

    public MenuViewModel(ContextFactory contextFactory)
    {
        _pizzaService = new PizzaService(contextFactory);
        _pizzaStore = new PizzaStore(_pizzaService);
        _pizzaStore.PizzasChanged += _OnPizzasChanged;

        AddPizzaCommand = new GenericCommand(_AddPizza);

        _GetIngredient();
    }

    private void _AddPizza()
    {
        var pizza = new Pizza()
        {
            Name = InputName ?? "",
            Price = InputPrice ?? 0f,
            Ingredients = Ingredients.Where(i => i.IsSelected)
        };

        InputName = null;
        InputPrice = null;
        _GetIngredient();

        OnPropertyChanged(nameof(InputName));
        OnPropertyChanged(nameof(InputPrice));
        OnPropertyChanged(nameof(Ingredients));

        _pizzaStore.AddPizza(pizza);
    }

    private static IEnumerable<FormattedPizza> _GetFormattedPizzas(IEnumerable<Pizza> pizzas) => pizzas.Select(p =>
        new FormattedPizza()
        {
            Name = p.Name,
            Ingredients = string.Join(", ", p.Ingredients.Select(i => i.Name)),
            Price = $"${p.Price:0.00}"
        });

    private void _OnPizzasChanged() => OnPropertyChanged(nameof(Pizzas));

    private async void _GetIngredient()
    {
        var ingredients = await _pizzaService.GetIngredients();

        Ingredients = ingredients.Select(ingredient => new SelectableIngredient()
            { Id = ingredient.Id, Name = ingredient.Name, IsSelected = false }).ToList();
    }
}