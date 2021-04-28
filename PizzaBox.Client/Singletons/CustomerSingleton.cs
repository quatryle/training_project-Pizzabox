using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomerSingleton
  {
    private static CustomerSingleton _instance;
    private readonly PizzaBoxContext _context;

    public List<Customer> Customers { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static CustomerSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new CustomerSingleton(context);
      }

      return _instance;

    }

    /// <summary>
    /// 
    /// </summary>
    private CustomerSingleton(PizzaBoxContext context)
    {
      _context = context;
      Customers = _context.Customers.ToList();
    }
  }
}