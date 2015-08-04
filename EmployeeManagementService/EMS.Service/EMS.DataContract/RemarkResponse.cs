﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EMS.DataContract
{
   
    [Serializable]
    [DataContract]
    public class RemarkResponse : Result
    {
        [DataMember]
        public Remark Remark
        {
            get;
            set;
        }
    }
}
