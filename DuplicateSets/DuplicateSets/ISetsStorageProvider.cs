using System.Collections.Generic;

namespace DuplicateSets
{
    /// <summary>
    /// Storage provider interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISetsStorageProvider<T>
    {
        /// <summary>
        /// Stores the set.
        /// </summary>
        /// <param name="hashKey">The hash key.</param>
        /// <param name="set">The set.</param>
        void StoreSet(object hashKey, T[] set);

        /// <summary>
        /// Gets the sets.
        /// </summary>
        /// <param name="hashKey">The hash key.</param>
        /// <returns></returns>
        IEnumerable<T[]> GetSets(object hashKey);
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns></returns>
        int GetCount();
        /// <summary>
        /// Gets the freequent set.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T[]> GetFreequentSet();
        /// <summary>
        /// Stores the invalid set.
        /// </summary>
        /// <param name="set">The set.</param>
        void StoreInvalidSet(string set);
        /// <summary>
        /// Gets the invalid sets.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetInvalidSets();
        /// <summary>
        /// Gets the duplicates count.
        /// </summary>
        /// <returns></returns>
        int GetDuplicatesCount();
    }
}