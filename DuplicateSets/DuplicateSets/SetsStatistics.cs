

namespace DuplicateSets
{
    using System.Collections.Generic;

    /// <summary>
    /// Type for aggregation of Statistics 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetsStatistics<T>
    {
        /// <summary>
        /// The storage
        /// </summary>
        private ISetsStorageProvider<T> storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetsStatistics{T}"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public SetsStatistics(ISetsStorageProvider<T> storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total
        {
            get { return this.storage.GetCount(); }
        }

        /// <summary>
        /// Gets the freequent set.
        /// </summary>
        /// <value>
        /// The freequent set.
        /// </value>
        public IEnumerable<T[]> FreequentSet
        {
            get { return storage.GetFreequentSet(); }
        }

        /// <summary>
        /// Gets the invalid sets.
        /// </summary>
        /// <value>
        /// The invalid sets.
        /// </value>
        public IEnumerable<string> InvalidSets
        {
            get { return storage.GetInvalidSets(); }
        }

        /// <summary>
        /// Gets the duplicates count.
        /// </summary>
        /// <value>
        /// The duplicates count.
        /// </value>
        public int DuplicatesCount {
            get { return storage.GetDuplicatesCount(); }
        }

        /// <summary>
        /// Gets the non duplicates count.
        /// </summary>
        /// <value>
        /// The non duplicates count.
        /// </value>
        public int NonDuplicatesCount
        {
            get { return this.Total - this.DuplicatesCount; }
        }
    }
}