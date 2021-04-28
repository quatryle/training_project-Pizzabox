using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new ChicagoStore() },
      new object[] { new NewYorkStore() }
    };

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "ChicagoStore");
      Assert.True(sut.ToString() == actual);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_NewYorkStore()
    {
      var sut = new NewYorkStore();

      Assert.True(sut.Name.Equals("NewYorkStore"));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="store"></param>
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      Assert.Equal(store.Name, store.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storeName"></param>
    /// <param name="x"></param>
    [Theory]
    [InlineData("ChicagoStore")]
    [InlineData("NewYorkStore")]
    public void Test_StoreNameSimple(string storeName)
    {
      Assert.NotNull(storeName);
    }
    [Fact]
    public void Test_OrderCost()
    {
      Domain.Models.Order sut = new Domain.Models.Order();
      Assert.NotNull(sut.TotalCost());
    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_CustomerName(PizzaBox.Domain.Models.Customer cust)
    {
      Assert.NotNull(cust.Name);
      Assert.Equal(cust.Name, cust.ToString());
    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_newPizza(APizza pizza)
    {
      Domain.Models.Order sut = new Domain.Models.Order();
      sut.customPizza();
    }
    [Fact]
    public void Test_Crust()
    {
      // Domain.Models.Crust sut;
      //Assert.True((sut.GetType).IsAssignableFrom(AComponent));
    }
    //test if crust is acomponent
    //
  }
}
