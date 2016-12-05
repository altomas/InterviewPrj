using System.Collections.Generic;

namespace DuplicateSets
{
    public interface ISetsStorageProvider<T>
    {
        void StoreSet(object hashKey, T[] set);

        IEnumerable<T[]> GetSets(object hashKey);
        int GetCount();
        IEnumerable<T[]> GetFreequentSet();
        void StoreInvalidSet(string set);
        IEnumerable<string> GetInvalidSets();
        int GetDuplicatesCount();
    }
}