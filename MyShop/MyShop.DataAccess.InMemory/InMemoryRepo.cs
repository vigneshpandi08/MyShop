using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepo<T>
    {
        ObjectCache cache=MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepo()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
                if(items==null)
                {
                    items=new List<T>();
                }
        }
        public void Commit()
        {
            cache[className] = items;
        }
        public void Insert(T t)
        {
            items.Add(t);
        }
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if(tToUpdate!=null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + "Not Found");
            }
        }
    }
}
