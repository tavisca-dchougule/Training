using EMS.BusinessDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessServiceContract
{
   public interface IEmployeeStorage
    {
         void Save(BusinessLayerEmployee employee);
         BusinessLayerEmployee GetById(string id);
         List<BusinessLayerEmployee> GetAll();
    }
}
