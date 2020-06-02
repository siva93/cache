namespace CacheProvider.Interface
{
    public interface ICacheProvider
    {
        T Get<T>(string key) where T : class;
        void Set<T>(string key, T value) where T : class;
        void Remove(string key);
    }
}