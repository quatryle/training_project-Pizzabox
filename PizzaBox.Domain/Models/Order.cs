using System;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using System.Text;
//using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    //private readonly FileRepository _fileRepository = new FileRepository();
    public Customer Customer { get; set; }
    public AStore Store { get; set; }
    public long StoreEntityId { get; set; }
    public APizza[] Pizza = new APizza[50];// { get; set; }
    public int index = 0;
    public DateTime orderTime;
    public double TotalCost()
    {
      double total = 0;
      for (int x = 0; x <= index; x++)
      {
        Console.WriteLine($"{Pizza[index]} - ${Pizza[index].price()}");
        total += Pizza[index].price();
      }
      orderTime = DateTime.Now;
      return total;
    }
    public void customPizza()
    {
      editPizzaCrust();
      bool loop = true;
      string input;
      while (loop)
      {
        Console.WriteLine("Would you like to add a topping?");
        input = Console.ReadLine();
        if (input.ToLower() == "yes")
        {
          addPizzaToppings();
          loop = true;
        }
        else if (input.ToLower() == "no")
          loop = false;
        else
          Console.WriteLine("Invalid response please enter yes or no");
      }
    }
    public void editPizza()
    {

      Console.WriteLine("Your Current Pizza Is");
      Console.WriteLine($"0:{Pizza[index].Crust} Crust");
      string input;
      bool loop = true;
      for (int x = 0; x < Pizza[index].Toppings.Count; x++)
      {
        Console.WriteLine($"{(x + 1)}: {Pizza[index].Toppings[x]}");
      }
      Console.WriteLine("Please input the number of the item you would like to edit");
      while (loop)
      {
        input = Console.ReadLine();
        if (input == "0")
        {
          editPizzaCrust();
          loop = false;
        }
        else if (Convert.ToInt32(input) > Pizza[index].Toppings.Count)
        {
          Console.WriteLine("Response out of range please try again");
          loop = true;
        }
        else
        {
          editPizzaToppings((Convert.ToInt32(input) - 1));
          loop = false;
        }
      }
      Console.WriteLine($"Your pizza is {Pizza[index]}");
      loop = true;
      Console.WriteLine("Edit another item?");
      while (loop)
      {
        input = Console.ReadLine();
        if (input.ToLower() == "yes")
        {
          editPizza();
          loop = false;
        }
        else if (input.ToLower() == "no")
          loop = false;
        else
          Console.WriteLine("Invalid response please enter yes or no");
      }

    }
    public void addPizzaToppings()
    {
      Pizza[index].Toppings.Add(new Topping());
      Pizza[index].Toppings[(Pizza[index].Toppings.Count - 1)].Name = "None";
      editPizzaToppings((Pizza[index].Toppings.Count - 1));
      if (Pizza[index].Toppings.Count == 8)
      {
        Console.WriteLine("Too many toppings! You are Limited to 5 additional toppings");
        Pizza[index].Toppings[(Pizza[index].Toppings.Count - 1)].Name = "None";
      }
      if (Pizza[index].Toppings[(Pizza[index].Toppings.Count - 1)].ToString() == "None")
      {
        Pizza[index].Toppings.RemoveAt((Pizza[index].Toppings.Count - 1));
        Console.WriteLine("Canceling additional item");
      }
    }
    public void editPizzaCrust()
    {
      string input;
      Console.WriteLine("What kind of crust would you like?");
      bool loop = true;
      while (loop)
      {
        input = Console.ReadLine();
        switch (input.ToLower())
        {
          case "plain":
            Pizza[index].Crust = "Plain";
            loop = false;
            break;
          case "deep dish":
            Pizza[index].Crust = "Deep Dish";
            loop = false;
            break;
          case "thin crust":
            Pizza[index].Crust = "Thin Crust";
            loop = false;
            break;
          default:
            Console.WriteLine("Your response was not understood please write the name of the crust you would like");
            loop = true;
            break;
        }
      }
    }
    public void editPizzaSize()
    {
      Console.WriteLine("What size Pizza would you like?");
      bool loop = true;
      while (loop)
      {
        string input = Console.ReadLine();
        switch (input.ToLower())
        {
          case "small":
            Pizza[index].Size = "Small";
            loop = false;
            break;
          case "medium":
            Pizza[index].Size = "Medium";
            loop = false;
            break;
          case "large":
            Pizza[index].Size = "Large";
            loop = false;
            break;
          default:
            Console.WriteLine("Response was not understood please enter small, medium, or large");
            break;
        }
      }
    }
    public void editPizzaToppings(int x)
    {
      Console.WriteLine("What would you like to add?");
      bool loop = true;
      while (loop)
      {
        string input = Console.ReadLine();
        switch (input.ToLower())
        {
          case "mozzarella cheese":
            Pizza[index].Toppings[x].Name = "Mozzarella Cheese";
            loop = false;
            break;
          case "cheddar cheese":
            Pizza[index].Toppings[x].Name = "Cheddar Cheese";
            loop = false;
            break;
          case "parmesan cheese":
            Pizza[index].Toppings[x].Name = "Parmesan Cheese";
            loop = false;
            break;
          case "provalone cheese":
            Pizza[index].Toppings[x].Name = "Provalone Cheese";
            loop = false;
            break;
          case "pepperoni":
            Pizza[index].Toppings[x].Name = "Pepperoni";
            loop = false;
            break;
          case "sausage":
            Pizza[index].Toppings[x].Name = "Sausage";
            loop = false;
            break;
          case "chicken":
            Pizza[index].Toppings[x].Name = "Chicken";
            loop = false;
            break;
          case "bacon":
            Pizza[index].Toppings[x].Name = "Bacon";
            loop = false;
            break;
          case "anchovy":
            Pizza[index].Toppings[x].Name = "Anchovy";
            loop = false;
            break;
          case "olives":
            Pizza[index].Toppings[x].Name = "Olive";
            loop = false;
            break;
          case "tomato":
            Pizza[index].Toppings[x].Name = "Tomato";
            loop = false;
            break;
          case "mushrooms":
            Pizza[index].Toppings[x].Name = "Mushroom";
            loop = false;
            break;
          case "peppers":
            Pizza[index].Toppings[x].Name = "Pepper";
            loop = false;
            break;
          case "onions":
            Pizza[index].Toppings[x].Name = "Onion";
            loop = false;
            break;
          case "cancel":
            loop = false;
            break;
          default:
            Console.WriteLine($"Your response {input} was not understood please write the name of the topping you would like or write cancel");
            loop = true;
            break;
        }
      }
    }
  }
}