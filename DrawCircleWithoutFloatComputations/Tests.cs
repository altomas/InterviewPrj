using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawCircleWithoutFloatComputations
{
  using NUnit.Framework;

  [TestFixture]
  public class Tests
  {


    [Test]
    public void Test()
    {
      var array = new Drawer().Circle(10);

      foreach (var point in array)
      {
        Console.WriteLine(point);
      }
    }
  }
}
