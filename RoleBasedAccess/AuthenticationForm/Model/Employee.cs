using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace AuthenticationForm.Model
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
        
    }

}