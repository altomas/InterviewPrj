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
    private string sentence;

    public ReverseWords(string sentence)
    {
      this.sentence = sentence;
    }

    internal object GetReversedValue()
    {
      char[] result = new char[this.sentence.Length];

      int index = 0;

      foreach (char crt in this.sentence)
      {

      }

      return new String(result);
    }
  }

  [TestFixture]
  public class Tests
  {
    [Test]
    public void ReverseWordsTest()
    {
      var undertest = new ReverseWords(" My test sentense ");

      Assert.AreEqual(" sentense test My ", undertest.GetReversedValue());

    }
  }

}


