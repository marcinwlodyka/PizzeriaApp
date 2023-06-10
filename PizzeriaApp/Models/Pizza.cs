using System.Collections.Generic;

namespace PizzeriaApp.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public IEnumerable<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
    public float Price { get; set; }
}