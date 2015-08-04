using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.DataContract
{
    [DataContract]
   public class Result
    {
        [DataMember]
       public Status Status;
       public Result()
       {
           Status = new Status();
           Status.StatusCode = "200";
           Status.Message = "OK";
       }

    }
}
