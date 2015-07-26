using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessServiceContract
{
    public interface ICacheManager
    {
        Object Get(string key);
        void Add(string key, Object value);
        void Flush();
        void Remove(string key);
    }
}
