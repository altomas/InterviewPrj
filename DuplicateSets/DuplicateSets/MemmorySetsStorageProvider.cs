

namespace DuplicateSets
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// In memmorey implementation of Set storage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="DuplicateSets.ISetsStorageProvider{T}" />
    public class MemmorySetsStorageProvider<T> : ISetsStorageProvider<T>
    {
        /// <summary>
        /// The invalid set
        /// </summary>
        List<string> InvalidSet = new List<string>();

        /// <summary>
        /// The storage
        /// </summary>
        Dictionary<object, List<T[]>> storage = new Dictionary<object, List<T[]>>();

        /// <summary>
        /// Stores the set.
        /// </summary>
        /// <param name="hashKey">The hash key.</param>
        /// <param name="set">The set.</param>
        public void StoreSet(object hashKey, T[] set)
        {
            List<T[]> sets = null;

            if (storage.ContainsKey(hashKey))
            {
                sets = storage[hashKey];
            }
            else
            {
               sets = storage[hashKey] = new List<T[]>();
            }
            
            sets.Add(set);
        }

        /// <summary>
        /// Gets the sets.
        /// </summary>
        /// <param name="hashKey">The hash key.</param>
        /// <returns></returns>
        public IEnumerable<T[]> GetSets(object hashKey)
        {
            if (storage.ContainsKey(hashKey))
            {
                return storage[hashKey];
            }

            return new T[0][];
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return storage.Count;
        }

        /// <summary>
        /// Gets the freequent set.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T[]> GetFreequentSet()
        {
            return this.storage.OrderBy(i => i.Value.Count).LastOrDefault().Value;
        }

        /// <summary>
        /// Stores the invalid set.
        /// </summary>
        /// <param name="set">The set.</param>
        public void StoreInvalidSet(string set)
        {
            InvalidSet.Add(set);
        }

        /// <summary>
        /// Gets the invalid sets.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetInvalidSets()
        {
            return InvalidSet;
        }

        /// <summary>
        /// Gets the duplicates count.
        /// </summary>
        /// <returns></returns>
        public int GetDuplicatesCount()
        {
            return this.storage.Count(i => i.Value.Count > 1);
        }
    }
}