﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AuthenticationForm.Model
{
     [DataContract]
    public class Remark
    {
        [DataMember]
        public DateTime DateTime
        {
            get;
            set;
        }

        [DataMember]
        public string Text
        {
            get;
            set;
        }
    }
       
    
}
