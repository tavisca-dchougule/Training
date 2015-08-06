﻿using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace RoleBasedAccess.Model
{
    [Serializable]
    [DataContract]
    public class Employee
    {
        [DataMember]
        public List<Remark> Remarks
        {
            get;
            set;
        }

        [DataMember]
        public string Id
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }
        [DataMember]
        public string LastName
        {
            get;
            set;
        }
        [DataMember]
        public string Email
        {
            get;
            set;
        }
        [DataMember]
        public string Designation
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
        public EmployeeResponse CreateEmployee()
        {
            var client = new HttpClient();
            EmployeeResponse responseEmployee = null;
            try
            {
                string EmployeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
                responseEmployee = client.UploadData<Employee, EmployeeResponse>(EmployeeManagementServiceUrl + "create", this);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            return responseEmployee;
        }
    }

}