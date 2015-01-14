// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindDuplicatesFixture.cs" company="">
//   
// </copyright>
// <summary>
//   The find duplicates fixture.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DuplicatesInArray
{
  using System;
  using System.Linq;

  /// <summary>
  /// The find duplicates fixture.
  /// </summary>
  public class FindDuplicatesFixture
  {
    #region Fields

    /// <summary>
    /// The n.
    /// </summary>
    private readonly int N;

    /// <summary>
    /// The under test.
    /// </summary>
    private readonly int[] underTest;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="FindDuplicatesFixture"/> class.
    /// </summary>
    /// <param name="N">
    /// The n.
    /// </param>
    public FindDuplicatesFixture(int N)
    {
      this.N = N;
      this.underTest = Enumerable.Range(1, N).ToArray();

      // spoil the array
      this.underTest[N / 2 - 1] = N / 2 - 1;
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The method 1.
    /// </summary>
    public void Method1()
    {
      // Logic:
      // Based on description we can assume that the array has whole sequence of numbers from 1 to N  
      // Imagine we have ideally instantiated array then each next number differs on 1 from previous one. 
      // So it is an arithmetic progression and Sum can be computed as (1 + N)*N/2
      // If our array has troubles then the sum will differs from ideal one.
      int idealSum = (1 + this.N) * this.N / 2;

      // compute sum of array under test via straightforward iteration 
      int realSum = 0;

      for (int i = 0; i < this.N; i++)
      {
        realSum += this.underTest[i];
      }

      if (realSum != idealSum)
      {
        Console.WriteLine(
          string.Format("The array contains duplicates, expected sum: {0} but real: {1}", idealSum, realSum));
      }

      // I see problem in this approach when N is really big number around 2^31 realSum variable will be overflowed
      // Complexity of this algorithm is O(N)
    }

    /// <summary>
    /// The method 2.
    /// </summary>
    public void Method2()
    {
      // Logic:
      // Based on description we can assume that the array has has whole sequence of numbers from 1 to N   
      // and difference of this arithmetic progression is 1
      // So if we sort an array first and then will iterate through array we can check that  a(n) - a(n-1) = 1  

      // sort array using any efficient algorithm with complexity is N*Log(N)
      Array.Sort(this.underTest);

      for (int i = 0; i < this.N; i++)
      {
        if (this.underTest[i] - this.underTest[i + 1] == 0)
        {
          Console.WriteLine(string.Format("The array contains duplicates: {0}", this.underTest[i]));
          break;
        }
      }

      // Complexity of this algorithm  will be N*Log(N) + N  what is less effective then first but does not have troubles with variable overflow. 
    }

    #endregion
  }
}