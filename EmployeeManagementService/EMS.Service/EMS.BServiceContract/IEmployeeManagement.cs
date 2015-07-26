

using EMS.BusinessDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EMS.BusinessServiceContract
{


    public interface IEmployeeManagement
    {

        BusinessLayerEmployee Create(BusinessLayerEmployee employee);


        BusinessLayerRemark AddRemark(string employeeId, BusinessLayerRemark remark);


    }
}
