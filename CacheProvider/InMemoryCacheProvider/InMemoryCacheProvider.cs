namespace CacheProvider.InMemoryCacheProvider
{
    using System;
    using Microsoft.Extensions.Caching.Memory;
    using CacheProvider.Interface;
    public class InMemoryCacheProvider : ICacheProvider
    {
        private readonly IMemoryCache _cache;
        public InMemoryCacheProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key) where T : class
        {
            T cachedResponse = null;
            _cache.TryGetValue(key, out cachedResponse);
            return cachedResponse;
        }

        public void Set<T>(string key, T value) where T : class
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            };
            _cache.Set(key, value, options);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}