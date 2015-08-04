
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EMS.BusinessDataContract;


namespace EMS.BusinessInterface
{

    public interface IEmployeeManager
    {

        BusinessLayerEmployee GetEmployee(string employeeId);
        List<BusinessLayerEmployee> GetAll();
        List<BusinessLayerRemark> GetRemark(string employeeId, string pageNumber,string rows);
        int GetRemarkCount(string employeeId);
    }
}
