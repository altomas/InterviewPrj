using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfPowerOfTwo
{
  using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
      [Test]
      [TestCase(0, true)]
      [TestCase(1, true)]
      [TestCase(2, true)]
      [TestCase(4, true)]
      [TestCase(8, true)]
      [TestCase(16, true)]

      [TestCase(3, false)]
      [TestCase(5, false)]
      [TestCase(22, false)]
      [TestCase(88, false)]
      [TestCase(63, false)]

      public void Test(int undertest, bool res)
      {
        Assert.AreEqual(res, ((undertest - 1) & undertest) == 0);
      }

      public void WriteBits(int num)
      {
        if (num == 0)
        {
          return;
        }

        var bit = Math.Abs(num % 2);
        this.WriteBits(num/2);
        
        Console.Write(bit);
      }


      [Test]
      public void GarageOn32Cars()
      {
        // Check whether the cur number is in garage

        int store = 0;

        store = this.SetInUse(store, 31);

        Assert.IsTrue(this.IsInUse(store, 31));

      }

      int SetInUse (int storage, int num)
      {
        return storage | 1 << num;
      }

      bool IsInUse(int storage, int num)
      {
        int shift = 1 << num;
        return (storage & shift) == shift;
      }
   }
}
