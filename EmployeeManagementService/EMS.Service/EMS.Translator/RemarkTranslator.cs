
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
            BusinessLayerRemark businessRemark;
            if (remark == null)
                businessRemark = null;
            else
                businessRemark = new BusinessLayerRemark(remark.Text);

            return businessRemark;
        }

        public Remark ConvertToServiceRemark(BusinessLayerRemark remark)
        {
            Remark serviceRemark;
            if (remark == null)
                serviceRemark = null;
            else
                serviceRemark = new Remark(remark.DateTime, remark.Text);

            return serviceRemark;
        }
    }
}
