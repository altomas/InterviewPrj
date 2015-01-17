using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_ReverseWords
{
  using NUnit.Framework;

  public class ReverseWords
  {
    private char[] sentence;

    public ReverseWords(string sentence)
    {
      
      this.sentence = sentence == null ? null : sentence.ToCharArray();
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

    public string GetReversedValue()
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

  [TestFixture]
  public class Tests
  {
    [Test]
    [TestCase(" My test sentense ", " sentense test My ")]
    [TestCase("  My test sentense ", " sentense test My  ")]
    [TestCase(" My test sentense  ", "  sentense test My ")]
    [TestCase(null, null)]
    [TestCase("","")]
    [TestCase(" ", " ")]
    public void ReverseWordsTest(string underTest, string expected)
    {
      var undertest = new ReverseWords(underTest);

      Assert.AreEqual(expected, undertest.GetReversedValue());

    }

    [Test]
    [TestCase(" My test sentense ", " sentense test My ")]
    [TestCase("  My test sentense ", " sentense test My  ")]
    [TestCase(" My test sentense  ", "  sentense test My ")]
    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    public void ReverseWordsTest2(string underTest, string expected)
    {
      var undertest = new ReverseWords(underTest);

      Assert.AreEqual(expected, undertest.GetReversedValue2());

    }
  }

}


