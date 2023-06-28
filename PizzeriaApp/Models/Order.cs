using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaApp.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public IEnumerable<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}