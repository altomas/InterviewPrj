
namespace DuplicateSets.Reporting
{
    using System;
    using System.Linq;

    /// <summary>
    /// Simple console reporting
    /// </summary>
    /// <seealso cref="DuplicateSets.ISetStorageVisitor" />
    public class SimpleConsoleReporting : ISetStorageVisitor
    {
        /// <summary>
        /// Accepts the specified set storage and build report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setStorage">The set storage.</param>
        public void Accept<T>(SetStorage<T> setStorage)
        {
            Console.WriteLine("Total :" + setStorage.Statistics.Total);
            var freequentSet = setStorage.Statistics.FreequentSet.ToArray();

            Console.WriteLine($"Amount of Duplicates: {setStorage.Statistics.DuplicatesCount}");
            Console.WriteLine($"Amount of Non-Duplicates: {setStorage.Statistics.NonDuplicatesCount}");

            Console.WriteLine($"TheMostFreequentSet: {freequentSet.Length}");

            foreach (var set in freequentSet)
            {
                Console.WriteLine(string.Join(",", set));
            }

            Console.WriteLine($"Invalid sets: {setStorage.Statistics.InvalidSets.Count()}");

            foreach (var set in setStorage.Statistics.InvalidSets)
            {
                Console.WriteLine(set);
            }
        }
    }
}
