using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_ReverseWords
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

  public class ReverseWords
  {
    private char[] sentence;

    public ReverseWords(string sentence)
    {
      
      this.sentence = sentence == null ? null : sentence.ToCharArray();
    }
    enum Direction 
    {
        left = 0,
        right= 2
    }

    public string GetReversedValue3()
    {
        int head = 0;
        int tail = this.sentence.Length -1;

        while (head < tail)
        { 
            var rightcrt = this.MoveAndPullCrt(this.sentence, head, Direction.right); 
            var leftcrt =  this.MoveAndPullCrt(this.sentence, tail, Direction.left);

            this.sentence[head] = leftcrt;
            this.sentence[tail] = rightcrt;

            head++;
            tail--;
        }

        return new String(this.sentence);
    }

    private char MoveAndPullCrt(char[] sentence, int start, Direction direction)
    {
        int dif = (int)direction - 1;

        var crt = this.sentence[start];

        if ( crt == ' ')
        {
            return crt;
        }

        while (this.sentence[start + dif] != ' ')
        {
            crt = this.sentence[start + dif];
            this.sentence[start + dif] = this.sentence[start];
        }

        return crt;
    }

    

    public string GetReversedValue2()
    {
      if (this.sentence == null)
      {
        return null;
      }

      Queue<char> result = new Queue<char>(this.sentence.Length);

      int index = this.sentence.Length - 1;

      Stack<char> word = new Stack<char>();

      while (index >= 0)
      {
        var crt = this.sentence[index--];

        if (crt == ' ')
        {
          while (word.Count > 0)
          {
            result.Enqueue(word.Pop());
          }

          result.Enqueue(crt);
          continue;
        }

        word.Push(crt);
      }

      while (word.Count > 0)
      {
        result.Enqueue(word.Pop());
      }

      return new string(result.ToArray());
    }

    public string GetReversedValue1()
    {
      if (this.sentence == null)
      {
        return null;
      }


      char[] result = new char[this.sentence.Length];

      Stack<Queue<char>> stack = new Stack<Queue<char>>();

      Queue<char> word = new Queue<char>();

      foreach (var crt in this.sentence)
      {
        if (crt == ' ')
        {
          stack.Push(word);
          word = new Queue<char>();
          word.Enqueue(crt);
          stack.Push(word);
          word = new Queue<char>();
          continue;
        }

        word.Enqueue(crt);
      }

      stack.Push(word);

      int index = 0;

      while (stack.Count > 0)
      {
        word = stack.Pop();

        while (word.Count > 0)
        {
          result[index++] = word.Dequeue();
        }
      }

      return new string(result);
    }
  }

   [TestClass]
  public class Tests
  {
     [TestMethod]
    //[TestCase(" My test sentense ", " sentense test My ")]
    //[TestCase("  My test sentense ", " sentense test My  ")]
    //[TestCase(" My test sentense  ", "  sentense test My ")]
    //[TestCase(null, null)]
    //[TestCase("","")]
    //[TestCase(" ", " ")]
    public void ReverseWordsTest(string underTest, string expected)
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

            RunWithMeasuring(() => { Assert.AreEqual(val.res, undertest.GetReversedValue1()); });
            RunWithMeasuring(() => { Assert.AreEqual(val.res, undertest.GetReversedValue2()); });
            RunWithMeasuring(() => { Assert.AreEqual(val.res, undertest.GetReversedValue3()); });
        });

    }

    public static void RunWithMeasuring(Action actionToRun)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        actionToRun();
        sw.Stop();

        Console.WriteLine(string.Format("{0}: execution time: {1} ticks", actionToRun.Method.Name, sw.ElapsedTicks));
    }

  }

}


