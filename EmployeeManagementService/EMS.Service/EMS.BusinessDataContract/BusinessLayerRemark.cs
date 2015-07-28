using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.BusinessDataContract
{

    [Serializable]
    public class BusinessLayerRemark
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
        public BusinessLayerRemark()
        {
            
        }
        public BusinessLayerRemark(DateTime dateTime, string text)
        {
            this.DateTime = dateTime;
            this.Text = text;
        }
    }
}

