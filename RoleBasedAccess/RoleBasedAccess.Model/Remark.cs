using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RoleBasedAccess.Model
{
     [DataContract]
    public class Remark
    {
        [DataMember]
        [Required]
        public DateTime DateTime
        {
            get;
            set;
        }
         [Required]
        [DataMember]
        public string Text
        {
            get;
            set;
        }
        public RemarkResponse AddRemark(string selectedEmployee)
        {
            HttpClient client = new HttpClient();
            RemarkResponse responseRemark = null;
            try
            {
                string employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
                responseRemark = client.UploadData<Remark, RemarkResponse>(employeeManagementServiceUrl + "employee/" + selectedEmployee + "/addremark",this);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return responseRemark;
        }

    }
       
    
}
