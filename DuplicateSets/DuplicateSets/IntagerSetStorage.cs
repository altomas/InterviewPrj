using System.Linq;

namespace DuplicateSets
{
    /// <summary>
    /// intager implementation of storage of sets
    /// </summary>
    /// <seealso cref="DuplicateSets.SetStorage{System.Int32}" />
    public class IntagerSetStorage : SetStorage<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntagerSetStorage"/> class.
        /// </summary>
        public IntagerSetStorage() : this(new MemmorySetsStorageProvider<int>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntagerSetStorage"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public IntagerSetStorage(ISetsStorageProvider<int> storage) : base(storage)
        {
        }

        /// <summary>
        /// Inputs the set.
        /// </summary>
        /// <param name="set">The set.</param>
        /// <returns></returns>
        public bool InputSet(string set)
        {
            int[] intSet;

            try
            {
                intSet = set.Replace(" ", string.Empty).Split(',').Select(i => int.Parse(i)).ToArray();
                return InputSet(intSet);
            }
            catch
            {
                RegisterInvalidSet(set);
            }

            return false;
        }
    }
}