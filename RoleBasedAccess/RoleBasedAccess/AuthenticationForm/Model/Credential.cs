using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AuthenticationForm.Model
{
    [Serializable]
    [DataContract]
    public class Credential
    {
        [DataMember]
        public string UserName
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
