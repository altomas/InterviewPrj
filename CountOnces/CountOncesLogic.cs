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
                undertest = undertest & (undertest - 1);
            }

            return count; 
        }
    }
}
