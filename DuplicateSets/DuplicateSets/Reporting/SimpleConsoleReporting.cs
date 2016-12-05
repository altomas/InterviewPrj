using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSets.Reporting
{
    public class SimpleConsoleReporting : ISetStorageVisitor
    {
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
