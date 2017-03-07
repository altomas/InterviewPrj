using System;

namespace ConsoleApplication
{
    //Find  balancing index of sequence of open '(' and closing ')' 
    //so sentence like "(())))(" should return 3 
    // "(())" return 1
    //cause we have 2 opening '((' and '))(' 2 closing brackets
    // what is outside or inside does not metter 
    //number of closing must be equal to number of  opening brackets
    // "((" or "))" will give an index 1 cause there is no opening or closing brackets
    // empty string must give you -1

    // Expected:
    // complexity  O(n)
    // memmory O(1)

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().SolutionMethod("(())))("));
            Console.WriteLine(new Solution().SolutionMethod("(())"));
            Console.WriteLine(new Solution().SolutionMethod("(("));
            Console.WriteLine(new Solution().SolutionMethod(")))"));
            Console.WriteLine(new Solution().SolutionMethod(""));
        }
    }

    class Solution {
      public int SolutionMethod(string S) {
        
        int frontIndex = 0;
        int tailIndex = S.Length - 1;
        int splitPosition = tailIndex;
        
        while(frontIndex < tailIndex)
        {
            while(S[frontIndex] != '(' && frontIndex < tailIndex)
            {
                frontIndex ++;
                continue;
            }

            if(frontIndex >= tailIndex)
            {
              break;
            }

             while(S[tailIndex] != ')' && frontIndex < tailIndex)
            {
                tailIndex --;
                continue;
            }

            if(frontIndex >= tailIndex)
            {
              break;
            }

            splitPosition = tailIndex-1;
            frontIndex++;
            tailIndex--;
        }

        return splitPosition;
    }
}
}
