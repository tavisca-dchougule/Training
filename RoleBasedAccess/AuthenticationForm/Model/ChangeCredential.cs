using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthenticationForm.Model
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
    }
}