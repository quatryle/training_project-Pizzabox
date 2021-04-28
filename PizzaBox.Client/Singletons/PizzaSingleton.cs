using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    public List<APizza> Pizzas { get; set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }
        Console.WriteLine(_instance);
        return _instance;
      }
    }
    private PizzaSingleton()
    {
      Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);

    }
  }
}
