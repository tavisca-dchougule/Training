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
            BusinessImplementator implementator= new BusinessImplementator();
            BusinessEmployee businessEmployee= implementator.GetEmployee(employeeId);
            ObjectTranslator translator = new ObjectTranslator();
            ServiceEmployee serviceEmployee = translator.ConvertToServiceEmployee(businessEmployee);
            Debug.WriteLine("id: "+serviceEmployee.Id);
            Debug.WriteLine("title: " + serviceEmployee.Title);
            Debug.WriteLine("fname: " + serviceEmployee.FirstName);
            Debug.WriteLine("lname: " + serviceEmployee.LastName);
            Debug.WriteLine("email: " + serviceEmployee.Email);
            return serviceEmployee;
        }


        public List<ServiceEmployee> GetAll()
        {
            BusinessImplementator implementator = new BusinessImplementator();
            List<BusinessEmployee> businessEmployeeList = implementator.GetAll();
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
