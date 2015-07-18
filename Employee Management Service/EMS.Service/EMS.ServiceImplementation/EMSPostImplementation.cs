using EMS.BDataContract;
using EMS.BServiceImplementation;
using EMS.DataContract;
using EMS.ServiceContract;
using EMS.Translator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.ServiceImplementation
{

    public class EMSPostImplementation :IEmployeeManagementService
    {
        public ServiceEmployee Create(ServiceEmployee employee)
        {
            BusinessImplementator implementator = new BusinessImplementator();
            ObjectTranslator translator = new ObjectTranslator();
            BusinessEmployee businessEmployee = translator.ConvertToBusinessEmployee(employee);
            ServiceEmployee serviceEmployee = translator.ConvertToServiceEmployee(implementator.Create(businessEmployee));
            return serviceEmployee;
        }


        public ServiceRemark AddRemark(string employeeId, ServiceRemark remark)
        {
            BusinessImplementator implementator = new BusinessImplementator();
            ObjectTranslator translator = new ObjectTranslator();
            BusinessRemark businessRemark = translator.ConvertToBusinessRemark(remark);
            ServiceRemark serviceRemark = translator.ConvertToServiceRemark(implementator.AddRemark(employeeId, businessRemark));
            return serviceRemark;

        }

    }
}
