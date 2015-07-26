using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.BusinessDataContract
{
    
    [Serializable]
    public class BusinessLayerEmployee
    {
        public List<BusinessLayerRemark> Remarks
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
       
        public BusinessLayerEmployee()
        {
            Remarks = new List<BusinessLayerRemark>();
        }
        public BusinessLayerEmployee(string id, string title, string firstname, string lastName, string email, List<BusinessLayerRemark> businessRemark)
        {
            
            this.Id = id;
            this.Title = title;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Email = email;
            this.Remarks = businessRemark;
        }
    }
}
