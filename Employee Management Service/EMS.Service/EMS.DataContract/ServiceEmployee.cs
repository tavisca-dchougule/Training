using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.DataContract
{
    [DataContract]
    public class ServiceEmployee
    {
        [DataMember]
        public ServiceRemark ServiceRemark
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


    
        public ServiceEmployee()
        {
            ServiceRemark = new ServiceRemark();
        }
        public ServiceEmployee(string id, string title, string firstname, string lastName, string email, ServiceRemark serviceRemark)
        {
            
            this.Id = id;
            this.Title = title;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Email = email;
            this.ServiceRemark = serviceRemark;
        }
    }
}
