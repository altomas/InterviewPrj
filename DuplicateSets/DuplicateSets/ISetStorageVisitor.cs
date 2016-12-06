namespace DuplicateSets
{
    /// <summary>
    /// Visitor interface for Storage type
    /// </summary>
    public interface ISetStorageVisitor
    {
        /// <summary>
        /// Accepts the specified set storage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setStorage">The set storage.</param>
        void Accept<T>(SetStorage<T> setStorage);
    }
}