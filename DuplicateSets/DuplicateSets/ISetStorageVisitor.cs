namespace DuplicateSets
{
    public interface ISetStorageVisitor
    {
        void Accept<T>(SetStorage<T> setStorage);
    }
}