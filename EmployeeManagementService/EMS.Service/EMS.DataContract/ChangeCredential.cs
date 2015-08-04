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
            public ChangeCredential()
            {
            }
            public ChangeCredential(string userName, string oldPassword, string newPassword)
            {
                this.UserName = userName;
                this.NewPassword = newPassword;
                this.OldPassword = oldPassword;
            }
    }
}
