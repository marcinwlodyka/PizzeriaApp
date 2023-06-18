using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaApp.Models;
using PizzeriaApp.Services;
using PizzeriaApp.ViewModels;

namespace PizzeriaApp.Stores;

public class PizzaStore
{
    private IEnumerable<Pizza> _pizzas = new List<Pizza>();
    private readonly PizzaService _pizzaService;

    public event Action? PizzasChanged;

    public IEnumerable<Pizza> Pizzas
    {
        get => _pizzas;
        private set
        {
            _pizzas = value;
            _OnPizzasChanged();
        }
    }

    public PizzaStore(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;

        Load();
    }

    private void _OnPizzasChanged() => PizzasChanged?.Invoke();

    public async void Load() => Pizzas = await _pizzaService.Get();

    public async void AddPizza(Pizza pizza)
    {
        await _pizzaService.Add(pizza);
        Load();
    }
}