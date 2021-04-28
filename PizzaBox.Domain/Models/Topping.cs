using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AComponent
  {
    public string Name;
    public override string ToString()
    {
      return Name;
    }
  }

}
