namespace CacheProvider.Apache_Ignite
{
    using System;
    using Apache.Ignite;
    using Apache.Ignite.Core;
    using Apache.Ignite.Core.Client;
    using Apache.Ignite.Core.Client.Cache;
    using CacheProvider.Interface;

    public class ApacheIgniteCacheProvider : ICacheProvider
    {
        private const string CacheName = "policy_details";
        private readonly IIgniteClient  _ignite ;
        public ApacheIgniteCacheProvider()
        {
            var cfg = new IgniteClientConfiguration("127.0.0.1");
            _ignite = Ignition.StartClient(cfg);
        }

        public T Get<T>(string key) where T : class
        {
            var cache = _ignite.GetCache<string, T>(CacheName);
            return cache.Get(key);
        }

        public void Set<T>(string key, T value) where T : class
        {
            var cache = _ignite.GetCache<string, T>(CacheName);
            cache.Put(key, value);
        }

        public void Remove(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}