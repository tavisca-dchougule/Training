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
    public class GetAllEmployeeResponse : Result
    {
        [DataMember]
        public List<Employee> AllEmployeeList
        {
            get;
            set;
        }
        public static GetAllEmployeeResponse GetAllEmployee()
        {
    
            var client = new HttpClient();
            GetAllEmployeeResponse employeeListResponse = null;
            try
            {
                string employeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
                employeeListResponse = client.GetData<GetAllEmployeeResponse>(employeeServiceUrl + "getall");
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return employeeListResponse;
        }
    }
}