

using EMS.BusinessDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EMS.BusinessInterface
{


    public interface IEmployeeManagementManager
    {

        BusinessLayerEmployee Create(BusinessLayerEmployee employee);


        BusinessLayerRemark AddRemark(string employeeId, BusinessLayerRemark remark);


    }
}
