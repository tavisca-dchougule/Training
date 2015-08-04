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
    public class GetAllEmployeeResponse : Result
    {
        [DataMember]
        public List <Employee> AllEmployeeList
        {
            get;
            set;
        }
    }
}
