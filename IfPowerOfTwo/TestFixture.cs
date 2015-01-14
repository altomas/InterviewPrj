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
      public void Test()
      {
        int undertest = 2;
        WriteBits(undertest);
        Console.WriteLine();
        WriteBits ( (undertest - 1) >> 1);
        Console.WriteLine();
        WriteBits(((undertest - 1) >> 1) + 1);
        Console.WriteLine();
        WriteBits((((undertest - 1) >> 1) + 1) << 1);
        Assert.IsTrue((((undertest - 1) >> 1) + 1) << 1 == undertest);

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
      public void Test2()
      {
        int undertest = 100;

        Assert.IsTrue((undertest ^ undertest) == 0);
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
