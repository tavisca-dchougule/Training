

using EMS.BusinessDataContract;
using EMS.BusinessServiceImplementation;
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
using EMS.EnterpriseLibrary;

namespace EMS.ServiceImplementation
{

    public class EMSGetImplementation : IEmployeeService
    {
       
        public Employee Get(string employeeId)
        {
            if (employeeId == null)
            {
                ArgumentException e = new ArgumentException();
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
           
            }
            BusinessImplementator implementator= new BusinessImplementator();
            Employee serviceEmployee = null;
            BusinessLayerEmployee businessEmployee = null;
            try
            {
                 businessEmployee = implementator.GetEmployee(employeeId);
               
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw;
                return null;
                
            }
            EmployeeTranslator employeeTranslator = new EmployeeTranslator();
            serviceEmployee = employeeTranslator.ConvertToServiceEmployee(businessEmployee);
            return serviceEmployee;
        }


        public List<Employee> GetAll()
        {
            BusinessImplementator implementator = new BusinessImplementator();
            List<BusinessLayerEmployee> businessEmployeeList = null;
            try
            {
                 businessEmployeeList = implementator.GetAll();
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw;
                return null;
            }
            EmployeeTranslator employeeTranslator = new EmployeeTranslator();
            List<Employee> serviceEmployeeList = new List<Employee>();

            BusinessLayerEmployee tempBusinessEmployee = null;
           
            for (int i = 0; i < businessEmployeeList.Count(); i++)
            {
                tempBusinessEmployee = businessEmployeeList.ElementAt(i);
                serviceEmployeeList.Add(employeeTranslator.ConvertToServiceEmployee(tempBusinessEmployee));
            }
            return serviceEmployeeList;
        }     
    }
}
