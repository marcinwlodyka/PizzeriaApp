using System.Collections.Generic;

namespace PizzeriaApp.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public IEnumerable<Pizza> Pizzas { get; set; } = new HashSet<Pizza>();
}