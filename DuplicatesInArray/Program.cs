using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicatesInArray
{
  using System.Diagnostics;

  class Program
  {
    static void Main(string[] args)
    {
      var underTest = new FindDuplicatesFixture(100000);

      RunWithMeasuring(underTest.Method1);
      RunWithMeasuring(underTest.Method2);

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
