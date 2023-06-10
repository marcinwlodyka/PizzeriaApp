using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;

namespace PizzeriaApp.Services;

public class PizzaService
{
    private readonly AppDbContext _context;

    public PizzaService() => _context = new AppDbContext();

    public async Task<IEnumerable<Pizza>> Get() => await _context.Pizzas.Include(p => p.Ingredients).ToListAsync();
}