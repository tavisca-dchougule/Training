using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthenticationForm.Model
{
    [Serializable]
    [DataContract]
    public class EmployeeResponse : Result
    {
        [DataMember]
        public Employee Employee
        {
            get;
            set;
        }
    }
}