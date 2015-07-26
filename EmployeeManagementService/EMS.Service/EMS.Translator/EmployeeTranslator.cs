
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
    
    public class EmployeeTranslator 
    {
        public BusinessLayerEmployee ConvertToBusinessEmployee(Employee employee)
        {
            RemarkTranslator remarkTranslator = new RemarkTranslator();
            List<BusinessLayerRemark> tempList = new List<BusinessLayerRemark>();
            for (int i = 0; i < employee.Remarks.Count(); i++)
            {
                tempList.Add( remarkTranslator.ConvertToBusinessRemark(employee.Remarks.ElementAt(i)));
            }
           
            BusinessLayerEmployee businessLayerEmployee = new BusinessLayerEmployee(employee.Id, employee.Title, employee.FirstName, employee.LastName, employee.Email, tempList);
            
            return businessLayerEmployee;

        }

        public Employee ConvertToServiceEmployee(BusinessLayerEmployee employee)
        {
            RemarkTranslator remarkTranslator = new RemarkTranslator();
            List<Remark> tempList = new List<Remark>();
            for (int i = 0; i < employee.Remarks.Count(); i++)
            {
                tempList.Add(remarkTranslator.ConvertToServiceRemark(employee.Remarks.ElementAt(i)));
            }
            
            Employee serviceEmployee = new Employee(employee.Id, employee.Title, employee.FirstName, employee.LastName, employee.Email, tempList);
           
            return serviceEmployee;
        }
        
        
    }
}
