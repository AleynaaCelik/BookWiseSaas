using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Helpers
{
    public class MemoryCacheHelper
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SetCache<T>(string key, T value, TimeSpan expirationTime)
        {
            _cache.Set(key, value, expirationTime);
        }

        public T GetCache<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }

        public void RemoveCache(string key)
        {
            _cache.Remove(key);
        }
    }
}
