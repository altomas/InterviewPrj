using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
 
    using System.Diagnostics;
    using _7_ReverseWords;
    using System.Linq;

    [TestClass]
    public class ReverseWordsTests
    {
        [TestMethod]
        public void ReverseWordsTest()
        {

            var cases = new[] { 
             
             new {arg = " My test sentense ",  res = " sentense test My "},
              new {arg = "  My test sentense ",  res = " sentense test My  "},
               new {arg = " My test sentense  ",  res = "  sentense test My "},
                new {arg = (string)null,  res = (string)null},
                 new {arg = "",  res = ""},
                  new {arg = " ",  res = " "},
                };

            cases.ToList().ForEach((val) =>
            {
                var undertest = new ReverseWords(val.arg);

                RunWithMeasuring(() => { Assert.AreEqual(val.res, undertest.GetReversedStackUsage()); });
                RunWithMeasuring(() => { Assert.AreEqual(val.res, undertest.GetReversedStackUsageOptimized()); });
                RunWithMeasuring(() => { Assert.AreEqual(val.res, undertest.GetReversedMemoryOptimization()); });
            });

        }

        public static void RunWithMeasuring(Action actionToRun)
        {
            Console.WriteLine();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            actionToRun();
            sw.Stop();

            Console.WriteLine(string.Format("{0}: execution time: {1} ticks", actionToRun.Method.Name, sw.ElapsedTicks));
        }
    }
}
