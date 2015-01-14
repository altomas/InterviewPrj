using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArraySum
{
  using NUnit.Framework;

  [TestFixture]
  public class TheTests
  {
  
    [Test]
    [TestCase(new int[] { -10, 5, -3, 15, 0, -7 }, new int[] { 5, -3, 15 })]
    public void Test1(int[] arrayUnderTest, int[] expectedSubArray)
    {
      int[] result = new TheLogic().GetSubArrayWithMaxSum(arrayUnderTest);

      CollectionAssert.AreEqual(expectedSubArray, result);
    }

    [TestCase(new int[] { -10, -5, -3, -15, -7 }, new int[] { -3 })]
    public void Test2(int[] arrayUnderTest, int[] expectedSubArray)
    {
      int[] result = new TheLogic().GetSubArrayWithMaxSum(arrayUnderTest);

      CollectionAssert.AreEqual(expectedSubArray, result);
    }


    [TestCase(new int[] { -10, -5, 3, -15, -7 }, new int[] { 3 })]
    public void Test3(int[] arrayUnderTest, int[] expectedSubArray)
    {
      int[] result = new TheLogic().GetSubArrayWithMaxSum(arrayUnderTest);

      CollectionAssert.AreEqual(expectedSubArray, result);
    }


    [TestCase(new int[] { -100, 5, 100, -105, 3, 100 }, new int[] { 5, 100 })]
    public void Test4(int[] arrayUnderTest, int[] expectedSubArray)
    {
      int[] result = new TheLogic().GetSubArrayWithMaxSum(arrayUnderTest);

      CollectionAssert.AreEqual(expectedSubArray, result);
    }

   [TestCase(new int[] { 87, -40, 59, 86, 97, -47, 21, 56, -18, 44}, new int[] { 87, -40, 59, 86, 97, -47, 21, 56, -18, 44 })]
    public void Test5(int[] arrayUnderTest, int[] expectedSubArray)
    {
      int[] result = new TheLogic().GetSubArrayWithMaxSum(arrayUnderTest);

      CollectionAssert.AreEqual(expectedSubArray, result);
    }
  }
}
