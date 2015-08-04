
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

            List<BusinessLayerRemark> tempList = new List<BusinessLayerRemark>();
            if (employee.Remarks == null)
                tempList = null;
            else
            {
                RemarkTranslator remarkTranslator = new RemarkTranslator();
                for (int i = 0; i < employee.Remarks.Count(); i++)
                {
                    tempList.Add(remarkTranslator.ConvertToBusinessRemark(employee.Remarks.ElementAt(i)));
                }
            }

            BusinessLayerEmployee businessLayerEmployee = new BusinessLayerEmployee(employee.Id, employee.Title, employee.FirstName, employee.LastName, employee.Email, tempList, employee.Password, employee.Designation);

            return businessLayerEmployee;

        }

        public Employee ConvertToServiceEmployee(BusinessLayerEmployee employee)
        {
            List<Remark> tempList = new List<Remark>();
            if (employee.Remarks == null)
                tempList = null;
            else
            {
                RemarkTranslator remarkTranslator = new RemarkTranslator();

                for (int i = 0; i < employee.Remarks.Count(); i++)
                {
                    tempList.Add(remarkTranslator.ConvertToServiceRemark(employee.Remarks.ElementAt(i)));
                }
            }

            Employee serviceEmployee = new Employee(employee.Id, employee.Title, employee.FirstName, employee.LastName, employee.Email, tempList, employee.Password, employee.Designation);

            return serviceEmployee;
        }


    }
}
