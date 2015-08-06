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
    public class ChangeCredential
    {
        [DataMember]
        public string UserName
        {
            get;
            set;
        }

        [DataMember]
        public string OldPassword
        {
            get;
            set;
        }
        [DataMember]
        public string NewPassword
        {
            get;
            set;
        }
        public EmployeeResponse CredentialChange()
        {
            var client = new HttpClient();
            EmployeeResponse responseEmployee = null;
            try
            {
                string employeeIdentityUrl = ConfigurationManager.AppSettings["employeeidentityurl"];
                responseEmployee = client.UploadData<ChangeCredential, EmployeeResponse>(employeeIdentityUrl + "changepassword", this);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return responseEmployee;
        }
    }
}