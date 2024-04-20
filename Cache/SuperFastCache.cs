using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Diana.Code.Chaallenge;

namespace Diana.Code.Challenge
{
    /// <question>
    /// Implement this class as required.
    /// </question>
    public class SuperFastCache<T> : ICacheStuff<T> where T : ICachedObject
    {
        private readonly ConcurrentDictionary<Guid, T> _cache = new ConcurrentDictionary<Guid, T>();

        public string CacheName => "Super Fast Cache";

        public SuperFastCache()
        {
        }

        public void AddItem(T newItem)
        {
            _cache.TryAdd(newItem.Id, newItem);
        }

        public string GetName(Guid id)
        {
            if (_cache.TryGetValue(id, out T item))
            {
                return item.Name;
            }
            return null;
        }

        T FindItem(Guid id)
        {
            _cache.TryGetValue(id, out T item);
            return item;
        }

        T ICacheStuff<T>.FindItem(Guid id)
        {
            return FindItem(id);
        }
    }
}
