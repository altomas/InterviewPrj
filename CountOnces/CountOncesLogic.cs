using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountOncesTests
{
    public class CountOncesLogic
    {
        //9. Give a very good method to count the number of ones in a "n" (e.g. 32) bit number.
        public static int GetOnces(int undertest)
        {
            int count = 0;

            while (undertest != 0)
            {
                count++;
                // I have found a way to turn off the right one bit what gave me a hint
                undertest = undertest & (undertest - 1);
                // there are more tricks 
                // x & (-x) - isolate the right "1" bit
                // ~x & (x+1) - isolate righ "0" bit
                // x | (x + 1) - Turn on the right "0" bit.
                
            }

            return count; 
        }
    }
}
