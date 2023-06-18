using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}