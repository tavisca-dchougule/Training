
using EMS.BDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EMS.BServiceContract
{


    public interface IEmployeeManagement
    {

        BusinessEmployee Create(BusinessEmployee employee);


        BusinessRemark AddRemark(string employeeId, BusinessRemark remark);


    }
}
