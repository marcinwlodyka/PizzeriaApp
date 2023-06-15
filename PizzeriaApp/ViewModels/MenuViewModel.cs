using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
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

public class MenuViewModel : ViewModelBase
{
    private readonly PizzaService _pizzaService = new PizzaService();
    public IEnumerable<FormattedPizza>? Pizzas { get; private set; }

    public MenuViewModel()
    {
        _UpdatePizzas();
    }
    
    private static string _FormatIngredients(IEnumerable<Ingredient> ingredients) =>
        string.Join(", ", ingredients.Select(i => i.Name));

    private async void _UpdatePizzas()
    {
        var pizzas = await _pizzaService.Get();

        Pizzas = pizzas.Select(p => new FormattedPizza() {
            Name = p.Name,
            Ingredients = _FormatIngredients(p.Ingredients),
            Price = $"{p.Price:0.00} zł"
        });
    }
}