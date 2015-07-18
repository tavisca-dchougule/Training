
using EMS.BDataContract;
using EMS.DataAccessLayer;
using EMS.BServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EMS.BServiceImplementation
{
    public class BusinessImplementator : IEmployee, IEmployeeManagement
    {

        public BusinessEmployee Create(BusinessEmployee employee)
        {

            FileHandler fileHandler = new FileHandler();
             fileHandler.Save(employee);
            return employee;
        }


        public BusinessRemark AddRemark(string employeeId, BusinessRemark remark)
        {
            BusinessEmployee employee = this.GetEmployee(employeeId);
            employee.BusinessRemark = remark;
            this.Create(employee);
            return remark;
        }


        public BusinessEmployee GetEmployee(string employeeId)
        {
            FileHandler fileHandler = new FileHandler();
            BusinessEmployee employee = fileHandler.GetById(employeeId);
            return employee;
        }


        public List<BusinessEmployee> GetAll()
        {
            FileHandler fileHandler = new FileHandler();
            List<BusinessEmployee> allEmployeeList = fileHandler.GetAll();
            return allEmployeeList;
        }


    }
}
