using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;

namespace PizzeriaApp.Services;

public class PizzaService
{
    private readonly ContextFactory _contextFactory;

    public PizzaService(ContextFactory contextFactory) => _contextFactory = contextFactory;

    /// <summary>
    /// Asynchronously gets all pizzas from database
    /// </summary>
    /// <returns>
    /// List of pizzas from database
    /// </returns>
    public async Task<List<Pizza>> Get()
    {
        var context = _contextFactory.CreateDbContext();

        return await context.Pizzas.Include(p => p.Ingredients).ToListAsync();
    }

    /// <summary>
    /// Asynchronously adds pizzas to database
    /// </summary>
    /// <param name="pizza">Represents a pizza you want to add</param>
    public async Task Add(Pizza pizza)
    {
        var context = _contextFactory.CreateDbContext();

        pizza.Ingredients = pizza.Ingredients
            .Select(i => context.Ingredients.Find(i.Id)!)
            .ToHashSet();

        await context.Pizzas.AddAsync(pizza);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Asynchronously gets ingredients from database
    /// </summary>
    /// <returns>List of all ingredients from database</returns>
    public async Task<List<Ingredient>> GetIngredients()
    {
        var context = _contextFactory.CreateDbContext();

        return await context.Ingredients.ToListAsync();
    }
}