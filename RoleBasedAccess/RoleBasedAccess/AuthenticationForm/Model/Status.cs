using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthenticationForm.Model
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public String StatusCode
        {
            get;
            set;
        }

        [DataMember]
        public string Message
        {
            get;
            set;
        }
       
    }
}