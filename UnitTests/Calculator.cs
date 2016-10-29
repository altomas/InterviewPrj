using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Test()
        {
            //Arrange
            var cases = new[] {

              new {arg = "3 + 2",  res = 5},
              new {arg = "3 + 2*2",  res = 7},
              new {arg = "(3 + 2)*2",  res = 10},
              new {arg = "-3 * 2",  res = -6},
             };

            var calc = new Calculator();

            //Act
            cases.ToList().ForEach((val) =>
            {
                //Assert
                Assert.AreEqual(val.res, calc.Compute(val.arg));
            });

        }
    }

    public class Calculator
    {
        Dictionary<string, short> OperatorsWeight = new Dictionary<string, short>()
        {
            { "+", 1 },
            { "*", 2 }
        };
         
        protected int CompareOperators(string a, string b)
        {
            return OperatorsWeight[a].CompareTo(OperatorsWeight[b]);
        }

        public int Compute(string text)
        {
            // fix first operator
            text = this.FixExpresion(text);

            var pattern = string.Format(@"({0})", 
                string.Join("|", 
                Regex.Escape("+"), 
                Regex.Escape("*"), 
                Regex.Escape("("), 
                Regex.Escape(")")
                ));
           
            var nodes = Regex.Split(text,  pattern).Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();


           return this.Compute(nodes);

        }

        protected string FixExpresion(string text)
        {
            text = text.Replace(" ", string.Empty);
            return text;
        }

        Dictionary<string, Func<Stack<int>, int>> FunctionsMap = new Dictionary<string, Func<Stack<int>, int>>()
        {
            { "+", (a) => a.Pop() + a.Pop()},
            { "*", (a) => a.Pop() * a.Pop()},
        };


        protected virtual int Compute(string[] values)
        {
            var operands = new Stack<int>();
            
            var operators = new Stack<string>();

            foreach (var token in values)
            {
                if (token == "(")
                {
                    operators.Push(token);
                    continue;
                }

                if (token == ")")
                {
                    var oprt = operators.Pop();
                    while (oprt != "(")
                    {
                        var func = FunctionsMap[oprt];

                        operands.Push(func.Invoke(operands));

                        oprt = operators.Pop();
                    }
                    continue;
                }


                if (FunctionsMap.ContainsKey(token))
                {
                    if (operators.Count > 0)
                    {
                        var prev = operators.Peek();

                        if (prev != "(" && CompareOperators(prev, token) > 0)
                        {
                            var func = FunctionsMap[operators.Pop()];

                            operands.Push(func.Invoke(operands));
                        }
                    }

                    operators.Push(token);
                    continue;
                }

                operands.Push(int.Parse(token));
            }

            while (operators.Count > 0)
            {
                var func = FunctionsMap[operators.Pop()];

                operands.Push(func.Invoke(operands));
            }

            return operands.Pop();
        }
    }
}
