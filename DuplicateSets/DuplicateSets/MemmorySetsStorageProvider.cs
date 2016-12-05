using System;
using System.Collections.Generic;
using System.Linq;

namespace DuplicateSets
{
    public class MemmorySetsStorageProvider<T> : ISetsStorageProvider<T>
    {
        List<string> InvalidSet = new List<string>();

        Dictionary<object, List<T[]>> storage = new Dictionary<object, List<T[]>>();

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

        public IEnumerable<T[]> GetSets(object hashKey)
        {
            if (storage.ContainsKey(hashKey))
            {
                return storage[hashKey];
            }

            return new T[0][];
        }

        public int GetCount()
        {
            return storage.Count;
        }

        public IEnumerable<T[]> GetFreequentSet()
        {
            return this.storage.OrderBy(i => i.Value.Count).LastOrDefault().Value;
        }

        public void StoreInvalidSet(string set)
        {
            InvalidSet.Add(set);
        }

        public IEnumerable<string> GetInvalidSets()
        {
            return InvalidSet;
        }

        public int GetDuplicatesCount()
        {
            return this.storage.Count(i => i.Value.Count > 1);
        }
    }
}