using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RoleBasedAccess.Model
{
    [Serializable]
    [DataContract]
    public class RemarkCountResponse : Result
    {
        [DataMember]
        public int RemarkCount
        {
            get;
            set;
        }
        public static RemarkCountResponse GetRemarkCount(string employeeId)
        {
            HttpClient client = new HttpClient();
            RemarkCountResponse remarkCountResponse = null;
            try
            {
              string EmployeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
                remarkCountResponse = client.GetData<RemarkCountResponse>(EmployeeServiceUrl + "employee/" + employeeId + "/getremarkcount");
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return remarkCountResponse;
        }
    }
}