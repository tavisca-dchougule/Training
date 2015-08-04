using EMS.BusinessDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessInterface.DBHandler
{
   public interface IEmployeeStoragePostCall
    {
         BusinessLayerEmployee Save(BusinessLayerEmployee employee); 
         BusinessLayerRemark AddRemark(string id, BusinessLayerRemark remark);
         
    }
}
