
using System.Linq;

namespace DuplicateSets
{
    public class IntagerSetStorage : SetStorage<int>
    {
        public IntagerSetStorage() : this(new MemmorySetsStorageProvider<int>())
        {
        }

        public IntagerSetStorage(ISetsStorageProvider<int> storage) : base(storage)
        {
        }

        public bool InputSet(string set)
        {
            int[] intSet;

            try
            {
                intSet = set.Replace(" ", string.Empty).Split(',').Select(i => int.Parse(i)).ToArray();
                return this.InputSet(intSet);
            }
            catch
            {
                this.RegisterInvalidSet(set);
            }

            return false;
        }
    }
}
