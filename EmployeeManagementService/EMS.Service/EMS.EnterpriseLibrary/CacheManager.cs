using Microsoft.Practices.EnterpriseLibrary.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.BusinessServiceContract;

namespace EMS.EnterpriseLibrary
{
    public class CacheManager : EMS.BusinessServiceContract.ICacheManager
    {
        public  Object Get(string key)
        {
            var cacheManager = CacheFactory.GetCacheManager();
            return cacheManager.GetData(key);

        }
        public void Add(string key,Object value)
        {
            var cacheManager = CacheFactory.GetCacheManager();
            cacheManager.Add(key,value);

        }
        public void Flush()
        {
            var cacheManager = CacheFactory.GetCacheManager();
            cacheManager.Flush();
        }
        public void Remove(string key)
        {
            var cacheManager = CacheFactory.GetCacheManager();
            cacheManager.Remove(key);
        }
    }
}
