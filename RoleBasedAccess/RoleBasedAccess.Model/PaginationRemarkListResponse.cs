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
    public class PaginationRemarkListResponse : Result
    {
        [DataMember]
        public List<Remark> PaginationRemarkList
        {
            get;
            set;
        }
        public static PaginationRemarkListResponse GetRemarkList(string employeeId)
        {

            HttpClient client = new HttpClient();
            PaginationRemarkListResponse remarkListResponse = null;

            try
            {
                string EmployeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
                remarkListResponse = client.GetData<PaginationRemarkListResponse>(EmployeeServiceUrl + "employee/" + employeeId + "/" + 1 + "/" + 3 + "/getremark");
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return remarkListResponse;
        }
    }
}