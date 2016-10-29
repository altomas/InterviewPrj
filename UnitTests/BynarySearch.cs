using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BynarySearchTest
    {
        [TestMethod]
        public void Test()
        {
            //Arrange
            var cases = new[] {
              new {arg = new[]{ 1,4,15,23,50 }, searchValue = 15,  res = 2},
              new {arg = new[]{ -4,-1,15,23,50 }, searchValue = -4,  res = 0},
              new {arg = new[]{ 1,4,15,23,50 }, searchValue = 1,  res = 0},
              new {arg = new[]{ 1,4,15,23,50 }, searchValue = 50,  res = 4},
              new {arg = new[]{ 1,4,15,23,50 }, searchValue = 33,  res = -1},
              new {arg = new[]{ 50 }, searchValue = 50,  res = 0},
              new {arg = new int[] {} , searchValue = 50,  res = -1},
             };

            // Act
            foreach (var testCase in cases)
            {
                Assert.AreEqual(testCase.res, new BynarySearch(testCase.arg).Find(testCase.searchValue));
            }
        }
    }

    public class BynarySearch
    {
        private int[] arg;

        public BynarySearch(int[] arg)
        {
            this.arg = arg;
        }

        public int Find(int searchValue)
        {
            // TODO: length border cases 0, 1

            var lowIndex = 0;
            var highIndex = arg.Length - 1;    
            

            while (lowIndex <= highIndex)
            {
                var midIndex = lowIndex + (highIndex - lowIndex) / 2;

                var temp = arg[midIndex];

                var comparrer = searchValue.CompareTo(temp);
                if (comparrer == 0)
                {
                    return midIndex;
                }

                if (comparrer > 0)
                {
                    lowIndex = midIndex + 1;
                    continue;
                }

                highIndex = midIndex - 1;
            }

            return -1;
        }
    }
}
