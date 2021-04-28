using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    public void Create(Order order)
    {
      _context.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}