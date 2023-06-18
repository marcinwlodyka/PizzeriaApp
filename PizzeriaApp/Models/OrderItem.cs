namespace PizzeriaApp.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Pizza Pizza { get; set; } = new Pizza();
    public Size Size { get; set; } = new Size();
    public Order Order { get; set; } = new Order();
}