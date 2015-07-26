
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
    public interface IEmployeeService
    {
        //  [WebGet(UriTemplate = "GetData/{employeeId}", ResponseFormat = WebMessageFormat.Json)]
       
        [WebInvoke(Method ="GET", UriTemplate ="/get/{employeeId}",ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Employee Get(string employeeId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/getall", ResponseFormat = WebMessageFormat.Json)]
        List<Employee> GetAll();
    }
}
