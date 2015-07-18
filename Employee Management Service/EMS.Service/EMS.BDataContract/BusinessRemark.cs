using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.BDataContract
{

    [Serializable]
    public class BusinessRemark
    {

        public DateTime DateTime
        {
            get;
            set;
        }


        public string Text
        {
            get;
            set;
        }
        public BusinessRemark()
        {
            DateTime = new DateTime();
            Text = "";
        }
        public BusinessRemark(DateTime dateTime, string text)
        {
            this.DateTime = dateTime;
            this.Text = text;
        }
    }
}

