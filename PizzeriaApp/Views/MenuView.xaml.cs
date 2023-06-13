using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using PizzeriaApp.Models;
using PizzeriaApp.Services;

namespace PizzeriaApp.Views;

public partial class MenuView : UserControl
{
    private readonly PizzaService _pizzaService;

    public MenuView()
    {
        _pizzaService = new PizzaService();

        InitializeComponent();
        _getItems();
    }

    private static string _formatIngredients(IEnumerable<Ingredient> ingredients) =>
        string.Join(", ", ingredients.Select(i => i.Name));

    private async void _getItems()
    {
        var pizzas = await _pizzaService.Get();

        PizzasList.ItemsSource = pizzas.Select(p => new
        {
            Name = p.Name,
            Ingredients = _formatIngredients(p.Ingredients),
            Price = $"{p.Price:0.00} zł"
        });
    }
}