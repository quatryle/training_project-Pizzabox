using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using System;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  [XmlInclude(typeof(MargheritaPizza))]
  [XmlInclude(typeof(PepperoniPizza))]
  [XmlInclude(typeof(SausagePizza))]
  [XmlInclude(typeof(ChickenPizza))]
  [XmlInclude(typeof(DeepDishPizza))]
  [XmlInclude(typeof(ThinCrustPizza))]
  [XmlInclude(typeof(FourCheesePizza))]
  public abstract class APizza : AModel
  {
    public string pName;
    public string Crust { get; set; }
    public string Size { get; set; }
    public long SizeEntityId { get; set; }
    public List<Topping> Toppings { get; set; }
    private double _initPrice = 6.95;
    private double _sizePrice;
    private double _topPrice = 1.85;
    public double price()
    {
      switch (Size)
      {
        case "Small":
          _sizePrice = 0;
          break;
        case "Medium":
          _sizePrice = 1.95;
          break;
        case "Large":
          _sizePrice = 3.9;
          break;
      }
      if (Toppings.Count > 2)
        return (_initPrice + _sizePrice + (Toppings.Count - 2) * _topPrice);
      else
        return (_initPrice + _sizePrice);
    }
    protected APizza()
    {
      Factory();
    }
    /// <summary>
    /// 
    /// </summary>
    protected virtual void Factory()
    {
      //AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddCrust()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddSize()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddToppings()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }
      return $"{pName} - {Crust} Crust, {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}
