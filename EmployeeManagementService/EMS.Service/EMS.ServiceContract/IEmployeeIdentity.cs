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
    public interface IEmployeeIdentity
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/authenticate", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EmployeeResponse Authenticate(Credential credential);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/changepassword", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EmployeeResponse ChangePassword(ChangeCredential changePassword);
    }
}
