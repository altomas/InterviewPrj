using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_ReverseWords
{
  using System.ComponentModel;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

  public class ReverseWords
  {
    private char[] sentence;

    public ReverseWords(string sentence)
    {
      
      this.sentence = sentence == null ? null : sentence.ToCharArray();
    }



    public string GetReverseSmartOne()
    {
      if (this.sentence == null)
      {
        return null;
      }

      //Get a mirror
      int head = 0;
      int tail = this.sentence.Length - 1;
      

      this.ReverseOrder(head, tail);

      return new string(this.sentence);
    }

    private void ReverseOrder(int head, int tail)
    {
      // Compexity is 2N 
      // memory consumption: a few variables -  O(1) space

      int hWordBegin = head;
      int tWordend = tail;
      
      while (head <= tail)
      {
        var crtHead = this.sentence[head];
        var crtTail = this.sentence[tail];

        this.sentence[head] = crtTail;
        this.sentence[tail] = crtHead;


        if (crtTail == ' ')
        {
          this.Swap(hWordBegin, head - 1);
          hWordBegin = head + 1;

          if (tail - head == 1)
          {
            this.Swap(tail, tWordend);
            return;
          }
        }
        
        if (crtHead == ' ')
        {
          this.Swap(tail + 1, tWordend);
          tWordend = tail - 1;

          if (tail - head == 1)
          {
            this.Swap(hWordBegin, head);
            return;
          }
        }

        if (tail == head)
        {
          this.Swap(hWordBegin, head);
          this.Swap(tail, tWordend);
          return;
        }

        head++;
        tail--;
      }
    }


    private void Swap(int head, int tail)
    {
      while (head < tail)
      {
        var crtHead = this.sentence[head];
        var crtTail = this.sentence[tail];

        this.sentence[head] = crtTail;
        this.sentence[tail] = crtHead;

        head++;
        tail--;
      }
    }

    enum Direction 
    {
        left = 0,
        right= 2
    }

    public string GetReversedBadMemoryOptimization()
    {
      // Compexity is quadratic!!!! - very bad

        if (this.sentence == null)
        {
            return null;
        }

        int head = 0;
        int tail = this.sentence.Length -1;

        while (head < tail)
        { 
            var rightcrt = this.MoveAndPullCrt(this.sentence, head, Direction.right); 
            var leftcrt = this.MoveAndPullCrt(this.sentence, tail, Direction.left);

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
      // Complexity of algorithm is O(2N) but without taking into account of Stack and Queue implementation - so finaly it can be near to quadratic.
      // beside problems with extra memory allocation


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


