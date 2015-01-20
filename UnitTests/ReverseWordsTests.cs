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
             
              new {arg = " My test sentense  ",  res = "  sentense test My "},
              new {arg = " My test sentense ",  res = " sentense test My "},
              new {arg = "  My test sentense ",  res = " sentense test My  "},
              new {arg = (string)null,  res = (string)null},
              new {arg = "",  res = ""},
              new {arg = " ",  res = " "},
                };

            cases.ToList().ForEach((val) =>
            {
                Assert.AreEqual(val.res, new ReverseWords(val.arg).GetReversedStackUsage());
                Assert.AreEqual(val.res, new ReverseWords(val.arg).GetReversedBadMemoryOptimization());
                Assert.AreEqual(val.res, new ReverseWords(val.arg).GetReverseSmartOne());
            });

        }

        [TestMethod]
        public void PerformanceTest()
        {
            var str = "Test";


            for (int i = 0; i < 100000; i++)
            {
                str += " Test";
            }

            RunWithMeasuring(() => { new ReverseWords(str).GetReversedBadMemoryOptimization(); });
            RunWithMeasuring(() => { new ReverseWords(str).GetReversedStackUsage(); });
            RunWithMeasuring(() => { new ReverseWords(str).GetReverseSmartOne(); });
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
