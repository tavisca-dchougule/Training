
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EMS.BusinessDataContract;
using EMS.BusinessInterface;
using EMS.EnterpriseLibrary;
using EMS.DataAccessLayer.DatabaseStorage;
using Microsoft.Practices.Unity;
using EMS.EnterpriseLibrary.Unity;

namespace EMS.BusinessImplementation
{
    public class BusinessImplementor : IEmployeeManager, IEmployeeManagementManager
    {
        public BusinessLayerEmployee Create(BusinessLayerEmployee employee)
        {         
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeStorage dataManager = container.Resolve<IEmployeeStorage>();
                dataManager.Save(employee);
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return employee;
        }


        public BusinessLayerRemark AddRemark(string employeeId, BusinessLayerRemark remark)
        {
            try
            {
                
                    IUnityContainer container = Factory.GetUnityConfiguration();
                    IEmployeeStorage dataManager = container.Resolve<IEmployeeStorage>();
                    dataManager.AddRemark(employeeId, remark);
                
            }
            catch(Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return remark;
        }


        public BusinessLayerEmployee GetEmployee(string employeeId)
        {
            BusinessLayerEmployee employee = null;
            ICacheManager cacheManager = null;
            try
            {
                
                IUnityContainer container = Factory.GetUnityConfiguration();
                cacheManager=container.Resolve<ICacheManager>();
               
               
                employee = (BusinessLayerEmployee)cacheManager.Get(employeeId);
                if (employee != null)
                    return employee;
                IEmployeeStorage dataManager = container.Resolve<IEmployeeStorage>();
                 employee = dataManager.GetById(employeeId);
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            cacheManager.Add(employeeId, employee);
            return employee;
        }


        public List<BusinessLayerEmployee> GetAll()
        {
            List<BusinessLayerEmployee> allEmployeeList = null;
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeStorage dataManager = container.Resolve<IEmployeeStorage>();
                allEmployeeList = dataManager.GetAll();
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return allEmployeeList;
        }
    }
}
