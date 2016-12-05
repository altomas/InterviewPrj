using System.Collections.Generic;

namespace DuplicateSets
{
    public class SetsStatistics<T>
    {
        private ISetsStorageProvider<T> storage;

        public SetsStatistics(ISetsStorageProvider<T> storage)
        {
            this.storage = storage;
        }
        
        public int Total
        {
            get { return this.storage.GetCount(); }
        }

        public IEnumerable<T[]> FreequentSet
        {
            get { return storage.GetFreequentSet(); }
        }

        public IEnumerable<string> InvalidSets
        {
            get { return storage.GetInvalidSets(); }
        }

        public int DuplicatesCount {
            get { return storage.GetDuplicatesCount(); }
        }

        public int NonDuplicatesCount
        {
            get { return this.Total - this.DuplicatesCount; }
        }
    }
}