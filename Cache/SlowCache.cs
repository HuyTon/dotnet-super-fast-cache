using System;
using System.Collections.Generic;
using System.Linq;
using Diana.Code.Chaallenge;

namespace Diana.Code.Challenge
{
    public class SlowCache<T> : ICacheStuff<T> where T : ICachedObject
    {
        public string CacheName => "Super Slow Cache x1000 slower that it should be :-(";

        public List<T> Items { get; private set; } = new List<T>();

        public SlowCache()
        {
            Items = new List<T>();
        }

        public void AddItem(T newItem)
        {
            Items.Add(newItem);
        }

        public string GetName(Guid id)
        {
            return FindItem(id)?.Name;
        }

        public T FindItem(Guid id)
        {
            return Items.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
