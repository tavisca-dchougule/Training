
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
            try
            {
                fileHandler.Save(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return employee;
        }


        public BusinessRemark AddRemark(string employeeId, BusinessRemark remark)
        {
            try
            {
                BusinessEmployee employee = this.GetEmployee(employeeId);
                employee.BusinessRemark = remark;
                this.Create(employee);
            }
            catch(Exception e)
            {
                throw e;
            }
            return remark;
        }


        public BusinessEmployee GetEmployee(string employeeId)
        {
            FileHandler fileHandler = new FileHandler();
            BusinessEmployee employee = null;
            try
            {
                 employee = fileHandler.GetById(employeeId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return employee;
        }


        public List<BusinessEmployee> GetAll()
        {
            FileHandler fileHandler = new FileHandler();
            List<BusinessEmployee> allEmployeeList = null;
            try
            {

                allEmployeeList = fileHandler.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
            return allEmployeeList;
        }


    }
}
