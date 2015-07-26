
using EMS.BusinessDataContract;
using EMS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.Translator
{
    
    public class RemarkTranslator 
    {
        
        
        public BusinessLayerRemark ConvertToBusinessRemark(Remark remark)
        {
            BusinessLayerRemark businessRemark = new BusinessLayerRemark(remark.DateTime,remark.Text);
            return businessRemark;

        }

        public Remark ConvertToServiceRemark(BusinessLayerRemark remark)
        {
           
            Remark serviceRemark = new Remark(remark.DateTime, remark.Text);
            return serviceRemark;
        }
    }
}
