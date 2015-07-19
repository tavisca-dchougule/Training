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
            if (employee == null)
                throw new ArgumentException();
            Guid g= Guid.NewGuid();
            employee.Id = g.ToString();
            BusinessImplementator implementator = new BusinessImplementator();
            ObjectTranslator translator = new ObjectTranslator();
            BusinessEmployee businessEmployee = translator.ConvertToBusinessEmployee(employee);
            ServiceEmployee serviceEmployee = null;
            try
            {
                serviceEmployee = translator.ConvertToServiceEmployee(implementator.Create(businessEmployee));
            }
            catch (Exception e)
            {
                throw e;
            }
            return serviceEmployee;
        }


        public ServiceRemark AddRemark(string employeeId, ServiceRemark remark)
        {
            if (employeeId == null || remark == null)
                throw new ArgumentException();
            BusinessImplementator implementator = new BusinessImplementator();
            ObjectTranslator translator = new ObjectTranslator();
            BusinessRemark businessRemark = translator.ConvertToBusinessRemark(remark);
            ServiceRemark serviceRemark = null;
            try
            {

                 serviceRemark = translator.ConvertToServiceRemark(implementator.AddRemark(employeeId, businessRemark));
            }
            catch (Exception e)
            {
                throw e;
            }
            return serviceRemark;

        }

    }
}
