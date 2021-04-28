using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreSingleton
  {
    private const string _path = @"data/stores.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
    private static StoreSingleton _instance;

    public List<AStore> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private StoreSingleton()
    {
      if (Stores == null)
      {
        Stores = _fileRepository.ReadFromFile<List<AStore>>(_path);
      }
    }
    /*public IEnumerable<Order> ViewOrders(AStore store)
    {

      //EF Loading = Eager Loading, Explicit loading,Lazy Loading
      // lambda - LINQ (linq to object) this is an example of Eager Loading
      var orders = _context.Stores.Include(s => s.Orders).Where(s = sName == store.Name); //LINQ = language interface query
      //Explicit Loading
      var st = _context.Stores.FirstOrDefault(s => s.Name == store.Name);
      _context.Entry<AStore>(store).Collection<orders>(s => s.Orders).Load(); //Load all orders with properties for one store
      // sql - LINQ(linq to sql) this is an example of lazy loading
      var orders2 = from r in _context.Stores
                    join ro in _context.Orders on r.EntityId == ro.StoreEntityId
                    where r.Name == store.Name
                    select ro;

    }*/
  }
}
