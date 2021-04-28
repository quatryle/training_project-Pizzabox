namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  public class AComponent : AModel
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
