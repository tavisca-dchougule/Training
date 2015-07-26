

using EMS.DataAccessLayer;
using EMS.BServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EMS.BusinessDataContract;
using EMS.BusinessServiceContract;
using EMS.EnterpriseLibrary;



namespace EMS.BusinessServiceImplementation
{
    public class BusinessImplementator : IEmployee, IEmployeeManagement
    {

        public BusinessLayerEmployee Create(BusinessLayerEmployee employee)
        {

            DatabaseHandler databaseHandler = new DatabaseHandler();
            try
            {
                databaseHandler.Save(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return employee;
        }


        public BusinessLayerRemark AddRemark(string employeeId, BusinessLayerRemark remark)
        {
            try
            {
                BusinessLayerEmployee employee = this.GetEmployee(employeeId);
                if (employee != null)
                {
                    DatabaseHandler databaseHandler = new DatabaseHandler();
                    databaseHandler.AddRemark(employee, remark);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return remark;
        }


        public BusinessLayerEmployee GetEmployee(string employeeId)
        {
          //  CacheManager cacheManager = new CacheManager();
           // BusinessLayerEmployee employee = (BusinessLayerEmployee)cacheManager.Get(employeeId);
          //  if (employee != null)
           //     return employee;
           // FileHandler fileHandler = new FileHandler();
            DatabaseHandler databaseHandler = new DatabaseHandler();
            BusinessLayerEmployee employee = null;
            try
            {
                 employee = databaseHandler.GetById(employeeId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return employee;
        }


        public List<BusinessLayerEmployee> GetAll()
        {
          //  FileHandler fileHandler = new FileHandler();
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List<BusinessLayerEmployee> allEmployeeList = null;
            try
            {

                allEmployeeList = databaseHandler.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
            return allEmployeeList;
        }


    }
}
