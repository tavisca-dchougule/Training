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

    public class EMSGetImplementation : IEmployeeService
    {
       
        public ServiceEmployee Get(string employeeId)
        {
            if (employeeId == null)
                throw new ArgumentException();
            BusinessImplementator implementator= new BusinessImplementator();
            ServiceEmployee serviceEmployee = null;
            BusinessEmployee businessEmployee = null;
            try
            {
                 businessEmployee = implementator.GetEmployee(employeeId);
               
            }
            catch (Exception e)
            {
                throw e;
            }
            ObjectTranslator translator = new ObjectTranslator();
            serviceEmployee = translator.ConvertToServiceEmployee(businessEmployee);
            return serviceEmployee;
        }


        public List<ServiceEmployee> GetAll()
        {
            BusinessImplementator implementator = new BusinessImplementator();
            List<BusinessEmployee> businessEmployeeList = null;
            try
            {
                 businessEmployeeList = implementator.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
            ObjectTranslator translator = new ObjectTranslator();
            List<ServiceEmployee> serviceEmployeeList = new List<ServiceEmployee>();

            BusinessEmployee tempBusinessEmployee = null;
           
            for (int i = 0; i < businessEmployeeList.Count(); i++)
            {
                tempBusinessEmployee = businessEmployeeList.ElementAt(i);
                serviceEmployeeList.Add(translator.ConvertToServiceEmployee(tempBusinessEmployee));
            }
            return serviceEmployeeList;
        }     
    }
}
