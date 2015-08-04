using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EMS.DataContract
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
        
        public Credential()
        {
        }
        public Credential(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            
        }

    }
}
