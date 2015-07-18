using EMS.BDataContract;
using EMS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.Translator
{
    
    public class ObjectTranslator 
    {
        public BusinessEmployee ConvertToBusinessEmployee(ServiceEmployee employee)
        {
            BusinessRemark businessRemark = this.ConvertToBusinessRemark(employee.ServiceRemark);
            BusinessEmployee businessEmployee = new BusinessEmployee(employee.Id, employee.Title, employee.FirstName, employee.LastName, employee.Email, businessRemark);
            
            return businessEmployee;

        }

        public ServiceEmployee ConvertToServiceEmployee(BusinessEmployee employee)
        {
            ServiceRemark serviceRemark = this.ConvertToServiceRemark(employee.BusinessRemark);
            ServiceEmployee serviceEmployee = new ServiceEmployee(employee.Id, employee.Title, employee.FirstName, employee.LastName, employee.Email, serviceRemark);
           
            return serviceEmployee;
        }
        
        public BusinessRemark ConvertToBusinessRemark(ServiceRemark remark)
        {
            BusinessRemark businessRemark = new BusinessRemark(remark.DateTime,remark.Text);
            return businessRemark;

        }

        public ServiceRemark ConvertToServiceRemark(BusinessRemark remark)
        {
           
            ServiceRemark serviceRemark = new ServiceRemark(remark.DateTime, remark.Text);
            return serviceRemark;
        }
    }
}
