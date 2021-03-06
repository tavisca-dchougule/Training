﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.DataContract
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public List <Remark> Remarks
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


    
        public Employee()
        {
            
        }
        public Employee(string id, string title, string firstname, string lastName, string email, List<Remark> serviceRemark,string password,string designation)
        {
            
            this.Id = id;
            this.Title = title;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Email = email;
            this.Remarks= serviceRemark;
            this.Password = password;
            this.Designation = designation;

        }
       
    }
}
