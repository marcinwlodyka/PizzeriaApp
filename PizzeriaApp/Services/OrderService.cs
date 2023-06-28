using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;

namespace PizzeriaApp.Services;

public class OrderService
{
    private readonly ContextFactory _contextFactory;

    public OrderService(ContextFactory contextFactory) => _contextFactory = contextFactory;

    /// <summary>
    /// Asynchronously gets all orders from database
    /// </summary>
    /// <returns>
    /// List of orders from database
    /// </returns>
    public async Task<List<Order>> Get()
    {
        var context = _contextFactory.CreateDbContext();

        return await context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Pizza)
            .ThenInclude(p => p.Ingredients)
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Size)
            .ToListAsync();
    }

    /// <summary>
    /// Asynchronously adds provided order to database
    /// </summary>
    /// <param name="order">
    /// Order which will be added to database
    /// </param>
    public async Task Add(Order order)
    {
        var context = _contextFactory.CreateDbContext();

        foreach (var orderItem in order.OrderItems)
        {
            var pizza = await context.Pizzas.FindAsync(orderItem.Pizza.Id);
            var size = await context.Sizes.FindAsync(orderItem.Size.Id);

            orderItem.Pizza = pizza ?? orderItem.Pizza;
            orderItem.Size = size ?? orderItem.Size;
        }

        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }


    /// <summary>
    /// Asynchronously gets all pizza sizes from database
    /// </summary>
    /// <returns>
    /// List of pizza sizes from database
    /// </returns>
    public async Task<List<Size>> GetSizes()
    {
        var context = _contextFactory.CreateDbContext();

        return await context.Sizes.ToListAsync();
    }

    public static float GetOrderItemPrice(OrderItem orderItem) =>
        orderItem.Pizza.Price * orderItem.Size.PriceMultiplier * orderItem.Amount;

    public static float GetOrderPrice(Order order) => order.OrderItems.Sum(GetOrderItemPrice);
}