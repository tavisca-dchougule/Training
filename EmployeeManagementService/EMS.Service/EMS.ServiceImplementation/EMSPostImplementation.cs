
using EMS.BusinessDataContract;
using EMS.BusinessImplementation;
using EMS.DataContract;
using EMS.EnterpriseLibrary;
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
        public Employee Create(Employee employee)
        {
            if (employee == null)
            {
                ArgumentException e = new ArgumentException();
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            Guid g= Guid.NewGuid();
            employee.Id = g.ToString();
            BusinessImplementor implementator = new BusinessImplementor();
            EmployeeTranslator employeeTranslator = new EmployeeTranslator();
            BusinessLayerEmployee businessLayerEmployee = employeeTranslator.ConvertToBusinessEmployee(employee);
            Employee serviceEmployee = null;
            try
            {
                serviceEmployee = employeeTranslator.ConvertToServiceEmployee(implementator.Create(businessLayerEmployee));
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return serviceEmployee;
        }


        public Remark AddRemark(string employeeId, Remark remark)
        {
            if (employeeId == null || remark == null)
            {
                ArgumentException e = new ArgumentException();
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            BusinessImplementor implementator = new BusinessImplementor();
            RemarkTranslator remarkTranslator = new RemarkTranslator();
            BusinessLayerRemark businessRemark = remarkTranslator.ConvertToBusinessRemark(remark);
            Remark serviceRemark = null;
            try
            {

                 serviceRemark = remarkTranslator.ConvertToServiceRemark(implementator.AddRemark(employeeId, businessRemark));
            }
            catch (Exception e)
            {
              
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return serviceRemark;

        }

    }
}
