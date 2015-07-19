using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.BDataContract
{
    
    [Serializable]
    public class BusinessEmployee
    {
        public BusinessRemark BusinessRemark
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }


        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
       
        public BusinessEmployee()
        {
            BusinessRemark = new BusinessRemark();
        }
        public BusinessEmployee(string id, string title, string firstname, string lastName, string email, BusinessRemark businessRemark)
        {
            
            this.Id = id;
            this.Title = title;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Email = email;
            this.BusinessRemark = businessRemark;
        }
    }
}
