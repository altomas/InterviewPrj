

namespace DuplicateSets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Generic Storage of sets
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetStorage<T>
    {
        /// <summary>
        /// The storage
        /// </summary>
        private readonly ISetsStorageProvider<T> storage;

        /// <summary>
        /// Gets the statistics.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public virtual SetsStatistics<T> Statistics { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetStorage{T}"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public SetStorage (ISetsStorageProvider<T> storage)
        {
            this.storage = storage;
            this.Statistics = new SetsStatistics<T>(storage);
        }

        /// <summary>
        /// Inputs the set.
        /// </summary>
        /// <param name="set">The set.</param>
        /// <returns></returns>
        public virtual bool InputSet(T[] set)
        {
            // get set hashKey
            var hashKey = this.GetHashkey(set.ToArray());

            // store set
            this.storage.StoreSet(hashKey, set);

            IEnumerable<T[]> sets = this.storage.GetSets(hashKey);

            return sets.Count() > 1;
        }

        /// <summary>
        /// Gets the hashkey.
        /// </summary>
        /// <param name="set">The set.</param>
        /// <returns></returns>
        protected virtual object GetHashkey(T[] set)
        {
            Array.Sort(set);

            return string.Join("|", set);
        }

        /// <summary>
        /// Accepts the visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public virtual void AcceptVisitor(ISetStorageVisitor visitor)
        {
            visitor.Accept(this);
        }


        /// <summary>
        /// Registers the invalid set.
        /// </summary>
        /// <param name="set">The set.</param>
        protected virtual void RegisterInvalidSet(string set)
        {
            storage.StoreInvalidSet(set);
        }
    }
}