using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Storing.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly OrderRepository _orderRepository = new OrderRepository();
    /// <summary>
    /// 
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      var order = new Order();
      string input;
      bool loop = true;
      bool outerLoop = true;
      Console.WriteLine("Welcome to PizzaBox");
      PrintListToScreen(_customerSingleton.Customers);
      var valid = int.TryParse(Console.ReadLine(), out int cust);
      while (!valid)
      {
        Console.WriteLine($"Please enter a numeric value between 1 and {_customerSingleton.Customers.Count}");
        valid = int.TryParse(Console.ReadLine(), out cust);
      }
      if (cust <= _customerSingleton.Customers.Count)
        order.Customer = SelectCustomer(cust);
      else
      {
        Console.WriteLine("What is your name?");
        order.Customer = new Customer();
        order.Customer.Name = Console.ReadLine();
        PrintStoreList();
      }
      order.Store = SelectStore();
      while (outerLoop)
      {
        PrintPizzaList();
        order.Pizza[order.index] = SelectPizza();
        order.editPizzaSize();
        if (order.Pizza[order.index].pName == "Custom")
          order.customPizza();
        Console.WriteLine("Would you like to edit your order yes or no?");
        while (loop)
        {
          input = Console.ReadLine();
          if (input.ToLower() == "yes")
          {
            order.editPizza();
            loop = false;
          }
          else if (input.ToLower() == "no")
            loop = false;
          else
            Console.WriteLine("Invalid response please enter yes or no");
        }
        PrintOrder(order.Pizza[order.index]);
        loop = true;
        while (loop)
        {
          Console.WriteLine("Would you like another pizza?");
          input = Console.ReadLine();
          if (input.ToLower() == "yes")
          {
            outerLoop = true;
            loop = false;
            order.index++;
          }
          else if (input.ToLower() == "no")
          {
            loop = false;
            outerLoop = false;
          }
          else
            Console.WriteLine("Invalid response please enter yes or no");
        }
      }
      _orderRepository.Create(order);
      var orders = _context.Orders.Where(o => o.Customer.Name == order.Customer.Name);
      Console.WriteLine($"Your total is ${order.TotalCost():C2}");
      //Console.WriteLine(orders);

    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(APizza pizza)
    {
      Console.WriteLine($"Your order is: {pizza}");
    }
    private static void PrintListToScreen(IEnumerable<object> items)
    {
      var index = 0;

      foreach (var item in items)
      {
        Console.WriteLine($"{++index} - {item}");
      }
      Console.WriteLine($"{index + 1} - New Customer");
    }

    private static Customer SelectCustomer(int input)
    {

      var customer = _customerSingleton.Customers[input - 1];
      PrintStoreList();

      return customer;
    }
    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      var pizza = _pizzaSingleton.Pizzas[input - 1];
      if (input == 1)
      {
        Console.WriteLine("Your Custom Pizza Must Be Assembled");
      }
      PrintOrder(pizza);
      return pizza;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);
      if (!valid)
      {
        return null;
      }
      return _storeSingleton.Stores[input - 1];
    }
  }
}