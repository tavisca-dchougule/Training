using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RoleBasedAccess.Model
{
    [Serializable]
    [DataContract]
    public class Credential
    {
        [DataMember]
        public string UserName
        {
            get;
            set;
        }

        [DataMember]
        public string Password
        {
            get;
            set;
        }
        public EmployeeResponse Authenticate()
        {
            var client = new HttpClient();
            EmployeeResponse employeeResponse = null;
            try
            {
                string employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeeidentityurl"];
                employeeResponse = client.UploadData<Credential, EmployeeResponse>(employeeManagementServiceUrl + "/authenticate", this);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return employeeResponse;
        }
    }
}
