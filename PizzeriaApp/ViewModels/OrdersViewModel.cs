using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.VisualBasic;
using PizzeriaApp.Commands;
using PizzeriaApp.Models;
using PizzeriaApp.Services;
using PizzeriaApp.Stores;

namespace PizzeriaApp.ViewModels;

public struct FormattedOrder
{
    public DateTime CreatedAt { get; set; }
    public string Items { get; set; }
}

public class OrdersViewModel : ViewModelBase
{
    private readonly PizzaStore _pizzaStore;
    private readonly OrderService _orderService;

    public ICommand AddOrderCommand { get; set; }
    public ICommand AddOrderItemCommand { get; set; }
    public ICommand CalculatePriceCommand { get; set; }

    public ObservableCollection<FormattedOrder> Orders { get; set; }
    public ObservableCollection<OrderItem> OrderItems { get; set; }
    public ObservableCollection<Size> Sizes { get; set; }

    public IEnumerable<Pizza> Pizzas => _pizzaStore.Pizzas;

    private float _orderTotal = 0f;

    public string OrderTotal
    {
        get => $"${_orderTotal:0.00}";
        set => float.TryParse(value, out _orderTotal);
    }

    public OrdersViewModel(ContextFactory contextFactory)
    {
        _orderService = new OrderService(contextFactory);

        LoadOrders();
        LoadSizes();

        var pizzaService = new PizzaService(contextFactory);
        _pizzaStore = new PizzaStore(pizzaService);

        OrderItems = new ObservableCollection<OrderItem>()
        {
            new()
            {
                Pizza = Pizzas.ElementAt(0),
                Amount = 1,
                Size = Sizes?.ElementAt(0) ?? new Size()
            }
        };
        UpdateOrderTotal();

        AddOrderCommand = new GenericCommand(AddOrder);
        AddOrderItemCommand = new GenericCommand(() => OrderItems.Add(new OrderItem()
        {
            Pizza = Pizzas.ElementAt(0),
            Amount = 1,
            Size = Sizes?.ElementAt(0) ?? new Size()
        }));
        CalculatePriceCommand = new GenericCommand(UpdateOrderTotal);
    }

    private List<FormattedOrder> GetFormattedOrders(IEnumerable<Order> orders) =>
        orders
            .Select(o => new FormattedOrder()
            {
                CreatedAt = o.CreateAt,
                Items = string.Join("\n", o.OrderItems)
            })
            .ToList();

    private async void LoadOrders() =>
        Orders = new ObservableCollection<FormattedOrder>(GetFormattedOrders(await _orderService.Get()));

    private async void AddOrder()
    {
        await _orderService.Add(new Order() { OrderItems = OrderItems });

        OrderItems.Clear();
        OrderItems.Add(new OrderItem()
        {
            Pizza = Pizzas.ElementAt(0),
            Amount = 1,
            Size = Sizes.ElementAt(0)
        });

        LoadOrders();
        OnPropertyChanged(nameof(Orders));
    }

    private async void LoadSizes() => Sizes = new ObservableCollection<Size>(await _orderService.GetSizes());

    private void UpdateOrderTotal()
    {
        OrderTotal = OrderService.GetOrderPrice(new Order() { OrderItems = OrderItems }).ToString();
        OnPropertyChanged(nameof(OrderTotal));
    }
}