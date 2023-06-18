using System.Collections.Generic;

namespace PizzeriaApp.Models;

public class Size
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public float PriceMultiplier { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}