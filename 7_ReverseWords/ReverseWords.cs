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

    public string GetReversedMemoryOptimization()
    {
        if (this.sentence == null)
        {
            return null;
        }

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

        if (crt == ' ')
        {
            return crt;
        }

        start += dif;

        while (this.sentence[start] != ' ')
        {
            var temp = this.sentence[start];
            this.sentence[start] = crt;
            crt = temp;
            start += dif;
        }

        return crt;
    }



    public string GetReversedStackUsage()
    {
      // straight forward alghorithm
      // This logic is not effision because requires additional memomory to store structs of  words and one more instance of sentence with new words order.
      // Complexity is 


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

    
  }
}


