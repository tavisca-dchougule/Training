
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
using EMS.BusinessInterface.DBHandler;

namespace EMS.BusinessImplementation
{
    public class EmployeeManager : IEmployeeManager
    {
        public BusinessLayerEmployee GetEmployee(string employeeId)
        {
            BusinessLayerEmployee employee = null;
            ICacheManager cacheManager = null;
            IUnityContainer container = Factory.GetUnityConfiguration();
            cacheManager = container.Resolve<ICacheManager>();
            employee = (BusinessLayerEmployee)cacheManager.Get(employeeId);
            if (employee != null)
                return employee;
            IEmployeeStorageGetCall dataManager = container.Resolve<IEmployeeStorageGetCall>();
            employee = dataManager.GetById(employeeId);
            cacheManager.Add(employeeId, employee);
            return employee;
        }
        public List<BusinessLayerEmployee> GetAll()
        {
            List<BusinessLayerEmployee> allEmployeeList = null;
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStorageGetCall dataManager = container.Resolve<IEmployeeStorageGetCall>();
            allEmployeeList = dataManager.GetAll();
            return allEmployeeList;
        }
        public List<BusinessLayerRemark> GetRemark(string employeeId, string pageNumber, string rows)
        {
            List<BusinessLayerRemark> allRemarkList = null;
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStorageGetCall dataManager = container.Resolve<IEmployeeStorageGetCall>();
            allRemarkList = dataManager.GetRemark_Pagination(employeeId, pageNumber, rows);
            return allRemarkList;
        }
        public int GetRemarkCount(string employeeId)
        {
            int remarkCount = 0;
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStorageGetCall dataManager = container.Resolve<IEmployeeStorageGetCall>();
            remarkCount = dataManager.GetRemarkCount(employeeId);
            return remarkCount;
        }
    }
}
