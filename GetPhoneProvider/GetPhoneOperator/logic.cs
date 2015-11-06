using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPhoneOperator
{
    public class logic
    {
        IDictionary<int, string> operatorsDictionary;

        int shift = 7; // 7 - is phone number digits amount

        public logic(IDictionary<int, string> operatorsDictionary)
        {
            this.operatorsDictionary = operatorsDictionary;
        }

        public string  GetOperatorName(long number)
        {

            long code = number / Convert.ToInt32(Math.Pow(10, shift));

            return operatorsDictionary[(int)code];

        }

    }
}
