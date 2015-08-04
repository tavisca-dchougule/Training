
using EMS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EMS.ServiceContract
{

    [ServiceContract]
    public interface IEmployeeManagementService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EmployeeResponse Create(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/employee/{employeeId}/addremark", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        RemarkResponse AddRemark(string employeeId, Remark remark);

       
    }
}
