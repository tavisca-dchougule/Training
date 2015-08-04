using EMS.BusinessDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessInterface.DBHandler
{
   public interface IEmployeeStorageGetCall
    {
        BusinessLayerEmployee GetById(string id);
        List<BusinessLayerEmployee> GetAll();
        List<BusinessLayerRemark> GetRemark_Pagination(string id, string pageNumber,string rows);
        int GetRemarkCount(string employeeId);
    }
}
