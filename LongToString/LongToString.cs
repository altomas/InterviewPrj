using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongToString
{
  using System.Diagnostics;

  using NUnit.Framework;

  public class LongToString
  {
    public string GetString(int number)
    {
      int index = 1;
      
      while ((number % 10 ^ index) >= 1)
      {
        index++;
      }

      char[] result = new char[index];
      
      index--;

      while (number >= 1)
      {
        result[index--] = (char)('0' + number % 10);
        number = number / 10;
      }

      return new string(result);
    }

    public string GetStringRecursive(int number)
    {
      return new string(this.GetCharsRecursive(number, 1));
    }

    public char[] GetCharsRecursive(int number, int iteration)
    {
      char[] result = null;

      if (number < 1)
      {
        return new char[iteration - 1];
      }
      
      var c = '0' + number % 10;

      result = this.GetCharsRecursive(number / 10, iteration + 1);

      result[result.Length - iteration] = (char)c;

      return result;
    }
  }

  [TestFixture]
  public class Tests
  {
    [Test]
    public void Test()
    {
      var result = new LongToString().GetString(123456789);

      Assert.AreEqual("123456789", result);
    }

    [Test]
    public void Test2()
    {
      var result = new LongToString().GetStringRecursive(123456789);

      Assert.AreEqual("123456789", result);
    }

    [Test]
    public void Test3()
    {
      RunWithMeasuring(() => { new LongToString().GetString(123456789); });
      RunWithMeasuring(() => { new LongToString().GetStringRecursive(123456789); });
    }

    public static void RunWithMeasuring(Action actionToRun)
    {
      Stopwatch sw = new Stopwatch();

      sw.Start();
      actionToRun();
      sw.Stop();

      Console.WriteLine(string.Format("{0}: execution time: {1} ticks", actionToRun.Method.Name, sw.ElapsedTicks));
    }
  }

}
