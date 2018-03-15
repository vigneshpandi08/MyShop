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
        }
    }
}
