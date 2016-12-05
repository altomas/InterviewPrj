using System;
using System.Collections.Generic;
using System.Linq;

namespace DuplicateSets
{
    public class SetStorage<T>
    {
        private readonly ISetsStorageProvider<T> storage;

        public virtual SetsStatistics<T> Statistics { get; private set; }

        public SetStorage (ISetsStorageProvider<T> storage)
        {
            this.storage = storage;
            this.Statistics = new SetsStatistics<T>(storage);
        }

        public virtual bool InputSet(T[] set)
        {
            // get set hashKey
            var hashKey = this.GetHashkey(set.ToArray());

            // store set
            this.storage.StoreSet(hashKey, set);

            IEnumerable<T[]> sets = this.storage.GetSets(hashKey);

            return sets.Count() > 1;
        }

        protected virtual object GetHashkey(T[] set)
        {
            Array.Sort(set);

            return string.Join("|", set);
        }

        public virtual void AcceptVisitor(ISetStorageVisitor visitor)
        {
            visitor.Accept(this);
        }


        protected virtual void RegisterInvalidSet(string set)
        {
            storage.StoreInvalidSet(set);
        }
    }
}