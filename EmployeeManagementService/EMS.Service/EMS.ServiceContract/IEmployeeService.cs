
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
        [WebInvoke(Method ="GET", UriTemplate ="/get/{employeeId}",ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        EmployeeResponse Get(string employeeId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/getall", ResponseFormat = WebMessageFormat.Json)]
        GetAllEmployeeResponse GetAll();
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/employee/{employeeId}/{pageNumber}/{rows}/getremark", ResponseFormat = WebMessageFormat.Json)]
        PaginationRemarkListResponse GetRemark(string employeeId, string pageNumber,string rows);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/employee/{employeeId}/getremarkcount", ResponseFormat = WebMessageFormat.Json)]
        RemarkCountResponse GetRemarkCount(string employeeId);
    }
}
