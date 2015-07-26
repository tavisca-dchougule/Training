using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.DataContract
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
        public Remark()
        {
            DateTime = new DateTime();
            Text = "";
        
        }
        public Remark(DateTime dateTime, string text)
        {
            this.DateTime = dateTime;
            this.Text = text;
        }
    }
}
