using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArraySum
{
  public class TheLogic
  {
    public int[] GetSubArrayWithMaxSum(int[] arrayUnderTest)
    {
      int head = 0;
      int tail = 0;

      int resultTail = 0;
      int resultHead = 0;
      int resultSum = arrayUnderTest[0];

      int sum = arrayUnderTest[0];

      for (int i = 1; i < arrayUnderTest.Length; i++)
      {
        if (sum < arrayUnderTest[i] && sum <= 0)
        {
          head = tail = i;
          sum = arrayUnderTest[i];
        }
        else
        {
          sum += arrayUnderTest[i];
          if (arrayUnderTest[i] > 0)
          {
            tail = i;
          }
        }

        if (sum > resultSum)
        {
          resultSum = sum;
          resultTail = tail;
          resultHead = head;
        }
      }

      int[] result = new int[resultTail - resultHead + 1];

      for (int i = resultHead; i <= resultTail; i++)
      {
        result[i - resultHead] = arrayUnderTest[i];
      }

      return result;
    }
  }
}
